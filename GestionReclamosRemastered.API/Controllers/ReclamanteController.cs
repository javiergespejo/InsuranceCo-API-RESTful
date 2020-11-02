using AutoMapper;
using GestionReclamosRemastered.API.Responses;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public ReclamanteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // GET: api/<ReclamanteController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var claimants = _unitOfWork.ReclamanteRepository.GetAll();
                var claimantsDto = _mapper.Map<IEnumerable<ReclamanteDto>>(claimants);
                var response = new ApiResponse<IEnumerable<ReclamanteDto>>(claimantsDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // GET api/<ReclamanteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var claimant = await _unitOfWork.ReclamanteRepository.GetByLongId(id);
                var claimantDto = _mapper.Map<ReclamanteDto>(claimant);
                var response = new ApiResponse<ReclamanteDto>(claimantDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound();
            }
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReclamanteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
