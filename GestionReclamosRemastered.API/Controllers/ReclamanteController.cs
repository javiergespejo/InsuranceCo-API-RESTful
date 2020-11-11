using AutoMapper;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamanteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReclamanteService _reclamanteService;
        public ReclamanteController(IUnitOfWork unitOfWork, IMapper mapper, IReclamanteService reclamanteService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _reclamanteService = reclamanteService;
        }

        /// <summary>
        /// Retrieve all claimants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ReclamanteDto>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(long? id_reclamante, long? Id_stro)
        {
            if (id_reclamante != null && Id_stro != null)
            {
                return Ok(_reclamanteService.GetReclamanteTieneMontosVinculados(id_reclamante, Id_stro));
                
            }
            var claimants = _unitOfWork.ReclamanteRepository.GetAll();
            if (claimants.Count() > 0)
            {
                var claimantsDto = _mapper.Map<IEnumerable<ReclamanteDto>>(claimants);
                //var response = new ApiResponse<IEnumerable<ReclamanteDto>>(claimantsDto);
                return Ok(claimantsDto);
            }
            return BadRequest();

        }

        /// <summary>
        /// Retrieve claimant by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ReclamanteDto))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var claimant = await _unitOfWork.ReclamanteRepository.GetByLongId(id);
            if (claimant != null)
            {
                var claimantDto = _mapper.Map<ReclamanteDto>(claimant);
                //var response = new ApiResponse<ReclamanteDto>(claimantDto);
                return Ok(claimantDto);
            }
            return NotFound();
        }

        /// <summary>
        /// Create claimant
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(ReclamanteDto claimantDto)
        {
            try
            {
                var claimant = _mapper.Map<Reclamante>(claimantDto);
                await _unitOfWork.ReclamanteRepository.Add(claimant);
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Edit claimant
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, ReclamanteDto claimantDto)
        {
            try
            {
                var claimant = _mapper.Map<Reclamante>(claimantDto);
                claimant.IdReclamante = id;
                var result = await _reclamanteService.UpdateClaimant(claimant);
                //var response = new ApiResponse<bool>(result);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete claimant by id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _reclamanteService.SoftDelete(id);
            if (isDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
