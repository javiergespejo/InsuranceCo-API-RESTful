using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<Siniestro>> GetSiniestroById(int id)
        {            
            var siniestro = await _unitOfWork.SiniestroRepository.GetById(id);
            if (siniestro == null)
            {
                return NotFound();
            }

            return siniestro;
        }

        [HttpPost]
        public async Task<ActionResult<Siniestro>> PostSiniestro(Siniestro siniestro)
        {
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

            return CreatedAtAction("PostSiniestro", new Siniestro());
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Siniestro>> PatchSiniestro(int id, Siniestro siniestro)
        {
            if (id != siniestro.IdStro)
            {
                return BadRequest();
            }

            _unitOfWork.SiniestroRepository.Update(siniestro);

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
        public async Task<ActionResult<Siniestro>> DeleteSiniestro(int id)
        {
            var siniestro = await _unitOfWork.UserRepository.GetById(id);
            if (siniestro == null)
            {
                return NotFound();
            }
            await _unitOfWork.SiniestroRepository.Delete(id);
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
    }
}
