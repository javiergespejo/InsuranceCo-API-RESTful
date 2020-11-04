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
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RecuperoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Recupero/
        [HttpGet]
        public async Task<IActionResult> GetAllRecupero()
        {
            try
            {
                var recuperos = await _unitOfWork.RecuperoRepository.GetAllAsync();
                var recuperosDto = _mapper.Map<List<RecuperoDto>>(recuperos);
                return Ok(recuperosDto);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // GET: api/Recupero/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecuperoById(long id)
        {
            var recupero = await _unitOfWork.RecuperoRepository.GetByLongId(id);
            if (recupero == null)
            {
                return NotFound();
            }

            var recuperoDto = _mapper.Map<RecuperoDto>(recupero);
            return Ok(recuperoDto);
        }

        // POST: api/Recupero
        [HttpPost]
        public async Task<IActionResult> PostRecupero(RecuperoDto recuperoDto)
        {
            var recupero = _mapper.Map<Recupero>(recuperoDto);
            try
            {
                await _unitOfWork.RecuperoRepository.Add(recupero);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("PostRecupero", recuperoDto);
        }

        // PATCH: api/Recupero/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchRecupero(long id, [FromBody] JsonPatchDocument<RecuperoDto> patchDocDto)
        {
            if (patchDocDto == null)
            {
                return BadRequest();
            }

            var recupero = await _unitOfWork.RecuperoRepository.GetByLongId(id);

            if (recupero == null)
            {
                return NotFound();
            }

            var patchDoc = _mapper.Map<JsonPatchDocument<Recupero>>(patchDocDto);
            patchDoc.ApplyTo(recupero, ModelState);

            var recuperoDto = _mapper.Map<RecuperoDto>(recupero);
            var isValid = TryValidateModel(recuperoDto);

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

        // DELETE: api/Recupero/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecupero(long id)
        {
            var recupero = await _unitOfWork.RecuperoRepository.GetByLongId(id);
            if (recupero == null)
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
