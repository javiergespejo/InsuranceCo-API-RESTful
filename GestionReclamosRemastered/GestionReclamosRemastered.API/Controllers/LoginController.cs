using GestionReclamosRemastered.API.Responses;
using GestionReclamosRemastered.Core.CustomEntities;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync(UserLogin userLogin)
        {
            try
            {
                var user = await _userService.Authentication(userLogin.User, userLogin.Password);
                if (user != null)
                {
                    var userDto = new UserDto()
                    {
                        IdUsuario = user.IdUsuario,
                        Nombre = user.Nombre,
                        CodUsuario = user.CodUsuario,
                        Password = user.Password,
                        IdTipoUsuario = user.IdTipoUsuario,
                        SnActivo = user.SnActivo
                    };
                    var response = new ApiResponse<UserDto>(userDto);
                    return Ok(response);
                }
                throw new Exception();
            }
            catch (Exception)
            {
                return NotFound();
            }
            
            
        }
    }
}
