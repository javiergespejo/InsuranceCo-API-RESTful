using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GestionReclamosRemastered.API.Responses;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionReclamosRemastered.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentativeController : Controller
    {
        private readonly IRepresentativeService _representativeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public RepresentativeController(IRepresentativeService representativeService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _representativeService = representativeService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetRepresentatives(string name)
        {
            try
            {
                var representativesList = await _representativeService.GetAllRepresentatives(name);
                var representativeDto = _mapper.Map<IEnumerable<RepresentativeDto>>(representativesList);
                //var response = new ApiResponse<IEnumerable<RepresentativeDto>>(representativeDto);
                return Ok(representativeDto);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRepresentative(int id)
        {
            try
            {
                var representative = await _representativeService.GetRepresentativeById(id);
                var representativeDto = _mapper.Map<RepresentativeDto>(representative);
                //var response = new ApiResponse<RepresentativeDto>(representativeDto);

                return Ok(representativeDto);

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> PostRepresentative(RepresentativeDto representativeDto)
        {
            try
            {
                var representative = _mapper.Map<Representante>(representativeDto);
                await _unitOfWork.RepresentativeRepository.Add(representative);
                await _unitOfWork.SaveChangesAsync();
                var response = new ApiResponse<string>("Representative saved");
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepresentative(int id)
        {
            try
            {
                var representative = await _unitOfWork.RepresentativeRepository.GetById(id);
                bool result = await _representativeService.DeleteRepresentative(representative);
                //var response = new ApiResponse<bool>(result);
                var response = new ApiResponse<string>("Representative could not be deleted");
                if (result) response.Data = "Representative deleted";
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepresentative(int id, RepresentativeDto representativeDto)
        {
            try
            {
                var user = _mapper.Map<Representante>(representativeDto);
                user.IdRepresentante = id;
                var result = await _representativeService.UpdateRepresentative(user);
                var response = new ApiResponse<string>("Representative could not be updated");
                if (result) response.Data = "Representative updated";
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
