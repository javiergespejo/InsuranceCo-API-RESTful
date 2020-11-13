using AutoMapper;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Core.QueryFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SiniestroController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISiniestroService _siniestroService;
        public SiniestroController(IUnitOfWork unitOfWork, IMapper mapper, ISiniestroService siniestroService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _siniestroService = siniestroService;
        }

        // GET: api/Siniestro
        [HttpGet]
        public async Task<IActionResult> GetAllSiniestros([FromQuery]SiniestroQueryFilter siniestroQueryFilter)
        {
            try
            {
                var siniestrosDto = await _siniestroService.GetAllSiniestros(siniestroQueryFilter);
                if (siniestrosDto == null)
                {
                    return NotFound();
                }
                return Ok(siniestrosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        //// GET: api/Siniestro/NroStro
        //[HttpGet("{nroStro}")]
        //public async Task<IActionResult> GetSiniestroByNroStro(long nroStro)
        //{
        //    var siniestroDto = await _siniestroService.GetSiniestroByNroStro(nroStro);
        //    if (siniestroDto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(siniestroDto);
        //}

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

        // POST: api/Siniestro
        [HttpPost]
        public async Task<IActionResult> PostSiniestro(SiniestroDto siniestroDto)
        {
            var siniestro = _mapper.Map<Siniestro>(siniestroDto);

            // El webforms no está trayendo el NroStro cuando se da el AltaSiniestro, por eso la siguiente línea
            siniestro.NroStro = await _unitOfWork.SiniestroRepository.NroStroAsign();

            if (await _unitOfWork.SiniestroRepository.SiniestroExist(siniestro))
            {
                return NotFound();
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiniestro(long id, SiniestroDto siniestroDto)
        {
            var siniestro = _mapper.Map<Siniestro>(siniestroDto);
            //siniestro.IdStro = id;

            try
            {
                _unitOfWork.SiniestroRepository.Update(siniestro);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(siniestroDto);

        }

        // PATCH: api/Siniestro/5
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

        // DELETE: api/Siniestro/5
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
