using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KargoAPI.Core.Dtos;
using KargoAPI.Core.Services;

namespace KargoAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly IUserService _userService;
        public Users(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
          var result = await _userService.CreateUser(createUserDto);
          if (result.Ok)
          {
              return Ok(result.CreateUserDto);
          }
          else
          {
              return BadRequest(result.ErrorList);
          }
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = await _userService.UserGetByName(HttpContext.User.Identity.Name);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }
            return Ok(user);
        }

    }
}
