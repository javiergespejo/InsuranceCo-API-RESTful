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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _unitOfWork.UserRepository.GetAll();
            if (users.Count() > 0)
            {
                var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
                var response = new ApiResponse<IEnumerable<UserDto>>(usersDto);
                return Ok(response);
            }
            return NotFound();
        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                var response = new ApiResponse<UserDto>(userDto);
                return Ok(response);
            }
            return NotFound();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<Usuario>(userDto);
                await _unitOfWork.UserRepository.Add(user);
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
        public async Task<IActionResult> Put(int id, UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<Usuario>(userDto);
                user.IdUsuario = id;
                var result = await _userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _userService.SoftDelete(id);
            if (isDeleted)
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}
