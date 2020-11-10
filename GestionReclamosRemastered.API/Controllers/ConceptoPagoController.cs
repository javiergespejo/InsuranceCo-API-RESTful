using AutoMapper;
using GestionReclamosRemastered.API.Responses;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptoPagoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConceptoPagoService _conceptoPagoService;
        private readonly IMapper _mapper;

        public ConceptoPagoController(IUnitOfWork unitOfWork, IMapper mapper, IConceptoPagoService conceptoPagoService)
        {
            _unitOfWork = unitOfWork;
            _conceptoPagoService = conceptoPagoService;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var conceptoPago = _conceptoPagoService.GetFullConceptoPagos();
                var conceptoPagoDto = _mapper.Map<IEnumerable<ConceptoPagoDto>>(conceptoPago);
                var response = new ApiResponse<IEnumerable<ConceptoPagoDto>>(conceptoPagoDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
                var conceptoPago = await _unitOfWork.ConceptoPagoRepository.GetById(id);
                if (conceptoPago != null)
                {
                    var conceptoPagoDto = _mapper.Map<ConceptoPagoDto>(conceptoPago);
                    //var response = new ApiResponse<ConceptoPagoDto>(conceptoPagoDto);
                    return Ok(conceptoPagoDto);
                }
                return NotFound(); 
        }
        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(ConceptoPagoDto conceptoPagoDto)
        {
            try
            {
                var conceptoPago = _mapper.Map<ConceptoPago>(conceptoPagoDto);
                await _unitOfWork.ConceptoPagoRepository.Add(conceptoPago);
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ConceptoPagoDto conceptoPagoDto)
        {
            try
            {
                var conceptoPago = _mapper.Map<ConceptoPago>(conceptoPagoDto);
                conceptoPago.IdConcepto = id;
                var result = await _conceptoPagoService.UpdateConceptoPago(conceptoPago);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var conceptoPago = await _unitOfWork.ConceptoPagoRepository.GetById(id);
                var result = await _conceptoPagoService.SoftDelete(conceptoPago);
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
