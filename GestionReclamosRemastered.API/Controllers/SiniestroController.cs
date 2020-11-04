using AutoMapper;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SiniestroController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SiniestroController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Siniestro
        [HttpGet]
        public async Task<IActionResult> GetAllSiniestros()
        {
            var siniestros = await _unitOfWork.SiniestroRepository.GetAllAsync();
            var siniestrosDto = _mapper.Map<List<SiniestroDto>>(siniestros);
            return Ok(siniestrosDto);
        }

        // GET: api/Siniestro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiniestroById(long id)
        {
            var siniestro = await _unitOfWork.SiniestroRepository.GetByLongId(id);
            if (siniestro == null)
            {
                return NotFound();
            }

            var siniestroDto = _mapper.Map<SiniestroDto>(siniestro);
            return Ok(siniestroDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostSiniestro(SiniestroDto siniestroDto)
        {
            var siniestro = _mapper.Map<Siniestro>(siniestroDto);
            if (await _unitOfWork.SiniestroRepository.SiniestroExist(siniestro))
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.SiniestroRepository.Add(siniestro);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("PostSiniestro", siniestroDto);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchSiniestro(long id, [FromBody] JsonPatchDocument<SiniestroDto> patchDocDto)
        {
            if (patchDocDto == null)
            {
                return BadRequest();
            }

            var siniestro = await _unitOfWork.SiniestroRepository.GetByLongId(id);

            if (siniestro == null)
            {
                return NotFound();
            }

            var patchDoc = _mapper.Map<JsonPatchDocument<Siniestro>>(patchDocDto);
            patchDoc.ApplyTo(siniestro, ModelState);

            var siniestroDto = _mapper.Map<SiniestroDto>(siniestro);
            var isValid = TryValidateModel(siniestroDto);

            if (!isValid)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiniestro(long id)
        {
            var siniestro = await _unitOfWork.SiniestroRepository.GetByLongId(id);
            if (siniestro == null)
            {
                return NotFound();
            }
            await _unitOfWork.SiniestroRepository.DeleteLong(id);
            try
            {
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
