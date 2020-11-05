using GestionReclamosRemastered.API.Responses;
using GestionReclamosRemastered.Core.CustomEntities;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        /// <summary>
        /// Retrieve JWT token
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AuthenticationAsync(UserLogin userLogin)
        {
            if (await UserIsValid(userLogin))
            {
                var token = GenerateToken(userLogin.User);
                return Ok(new { token });
            }
            var response = new ApiResponse<UserLogin>(userLogin);
            return NotFound(response);
        }

        private async Task<bool> UserIsValid(UserLogin login)
        {
            var user = await _userService.AuthenticationAsync(login.User, login.Password);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        private string GenerateToken(string userName)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName)
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(2)
            );

            //Signature
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
