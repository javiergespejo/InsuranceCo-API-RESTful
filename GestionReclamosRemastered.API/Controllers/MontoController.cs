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
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MontoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMontoService _montoService;
        private readonly IMapper _mapper;

        public MontoController (IUnitOfWork unitOfWork, IMapper mapper, IMontoService montoService)
        {
            _unitOfWork = unitOfWork;
            _montoService = montoService;
            _mapper = mapper;
        }

        //GET: api/<MontoController>
        [HttpGet]
        public IActionResult Get(long? id_stro)
        {
            if (id_stro != null)
            {
                var montos = _unitOfWork.MontoRepository.BuscarPagosPorIdSiniestroAPI(id_stro);
                return Ok(montos);
                
            };
            try
            {
                var montos = _montoService.GetFullMonto();
                var montosDto = _mapper.Map<IEnumerable<MontoDto>>(montos);
                var response = new ApiResponse<IEnumerable<MontoDto>>(montosDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //GET api/MontoController/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var monto = await _montoService.GetFullMontoById(id);
                var montoDto = _mapper.Map<MontoDto>(monto);
                var response = new ApiResponse<MontoDto>(montoDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        // POST api/<MontoController>
        [HttpPost]
        public async Task<IActionResult> Post(MontoDto montoDto)
        {
            try
            {
                var monto = _mapper.Map<Monto>(montoDto);
                await _unitOfWork.MontoRepository.Add(monto);
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<MontoController>/3
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MontoDto montoDto)
        {
            try
            {
                var monto = _mapper.Map<Monto>(montoDto);
                monto.IdReclamante = id;
                var result = await _montoService.UpdateMonto(monto);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // DELETE api/<MontoController>/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var user = await _unitOfWork.MontoRepository.GetById(id);
                var result = await _montoService.Delete(id);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
