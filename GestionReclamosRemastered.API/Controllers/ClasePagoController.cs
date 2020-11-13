using AutoMapper;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionReclamosRemastered.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClasePagoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClasePagoService _clasePagoService;
        public ClasePagoController(IUnitOfWork unitOfWork, IMapper mapper, IClasePagoService clasePagoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clasePagoService = clasePagoService;
        }
        // GET: api/<ClasePagoController>
        [HttpGet]
        public IActionResult Get()
        {
            var clases = _unitOfWork.ClasePagoRepository.GetAll();
            if (clases.Count() > 0)
            {
                var clasesDto = _mapper.Map<IEnumerable<ClasePagoDto>>(clases);
                //var response = new ApiResponse<IEnumerable<UserDto>>(usersDto);
                return Ok(clasesDto);
            }
            return NotFound();
        }

        // GET api/<ClasePagoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var clase = await _unitOfWork.ClasePagoRepository.GetById(id);
            if (clase != null)
            {
                var claseDto = _mapper.Map<ClasePagoDto>(clase);
                //var response = new ApiResponse<UserDto>(userDto);
                return Ok(claseDto);
            }
            return NotFound();
        }

        // POST api/<ClasePagoController>
        [HttpPost]
        public async Task<IActionResult> Post(ClasePagoDto claseDto)
        {
            try
            {
                var clase = _mapper.Map<ClasePago>(claseDto);
                await _unitOfWork.ClasePagoRepository.Add(clase);
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<ClasePagoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClasePagoDto claseDto)
        {
            try
            {
                var clase = _mapper.Map<ClasePago>(claseDto);
                clase.IdClasePago = id;
                var result = await _clasePagoService.UpdateClasePago(clase);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<ClasePagoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _clasePagoService.SoftDelete(id);
            if (isDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
