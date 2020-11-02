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
        private readonly ISiniestroRepository _siniestroRepository;
        public SiniestroController(ISiniestroRepository siniestroRepository)
        {
            _siniestroRepository = siniestroRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<SiniestroDto>> GetAllSiniestrosAsync()
        {
            var siniestros = await _siniestroRepository.GetAllAsync();
            return SiniestroDto.SiniestroDtoToEntityList(siniestros);
        }
    }
}
