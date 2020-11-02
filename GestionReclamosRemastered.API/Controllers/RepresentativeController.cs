using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GestionReclamosRemastered.API.Token_Validation;
using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GestionReclamosRemastered.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentativeController : Controller
    {
        private readonly IRepresentativeService _representativeService;
        private readonly IConfiguration _configuration;


        public RepresentativeController(IRepresentativeService representativeService, IConfiguration configuration)
        {
            _representativeService = representativeService;
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Representante>>> GetRepresentatives()
        {
            TokenValidator tkValidator = new TokenValidator(_configuration);
            string token = HttpContext.Request.Headers["Authorization"];
            if (tkValidator.ValidateToken(token))
            {

                return Ok();
            }
            return NotFound();
        }


    }
}
