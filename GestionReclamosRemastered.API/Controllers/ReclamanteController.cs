using AutoMapper;
using GestionReclamosRemastered.API.Responses;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.API.Controllers
{
    [Authorize]
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
        // GET: api/<ReclamanteController>
        [HttpGet]
        public IActionResult Get()
        {

            var claimants = _unitOfWork.ReclamanteRepository.GetAll();
            if (claimants.Count() > 0)
            {
                var claimantsDto = _mapper.Map<IEnumerable<ReclamanteDto>>(claimants);
                var response = new ApiResponse<IEnumerable<ReclamanteDto>>(claimantsDto);
                return Ok(response);
            }
            return BadRequest();

        }

        // GET api/<ReclamanteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var claimant = await _unitOfWork.ReclamanteRepository.GetByLongId(id);
            if (claimant != null)
            {
                var claimantDto = _mapper.Map<ReclamanteDto>(claimant);
                var response = new ApiResponse<ReclamanteDto>(claimantDto);
                return Ok(response);
            }
            return NotFound();
        }

        // POST api/<ReclamanteController>
        [HttpPost]
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

        // PUT api/<ReclamanteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ReclamanteDto claimantDto)
        {
            try
            {
                var claimant = _mapper.Map<Reclamante>(claimantDto);
                claimant.IdReclamante = id;
                var result = await _reclamanteService.UpdateClaimant(claimant);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<ReclamanteController>/5
        [HttpDelete("{id}")]
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
