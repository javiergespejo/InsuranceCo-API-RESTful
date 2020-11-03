using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GestionReclamosRemastered.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiniestroController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SiniestroController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Siniestro
        [HttpGet]
        public async Task<IEnumerable<SiniestroDto>> GetAllSiniestros()
        {
            var siniestros = await _unitOfWork.SiniestroRepository.GetAllAsync();
            return SiniestroDto.SiniestroDtoToEntityList(siniestros);
        }

        // GET: api/Siniestro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SiniestroDto>> GetSiniestroById(long id)
        {
            var siniestro = await _unitOfWork.SiniestroRepository.GetByLongId(id);
            if (siniestro == null)
            {
                return NotFound();
            }

            SiniestroDto siniestroDto = new SiniestroDto(siniestro);

            return siniestroDto;
        }

        [HttpPost]
        public async Task<ActionResult<SiniestroDto>> PostSiniestro(SiniestroDto siniestroDto)
        {
            var siniestro = siniestroDto.ToSiniestroEntity();
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
        public async Task<ActionResult<Siniestro>> PatchSiniestro(long id, [FromBody] JsonPatchDocument<Siniestro> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var siniestro = await _unitOfWork.SiniestroRepository.GetByLongId(id);

            if (siniestro == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(siniestro, ModelState);

            var isValid = TryValidateModel(siniestro);

            if (!isValid)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return Ok(siniestro);
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
