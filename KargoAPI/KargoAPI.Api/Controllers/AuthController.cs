using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KargoAPI.Core.Dtos;
using KargoAPI.Core.Models;
using KargoAPI.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace KargoAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly UserManager<UserApp> _userManager;


        public AuthController(IAuthenticationService authenticationService, IUserService userService, UserManager<UserApp> userManager)
        {
            _authenticationService = authenticationService;
            _userManager = userManager;
            _userService = userService;
        }

        //api/auth/
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginDto loginDto)
        {
            var user = _userManager.FindByEmailAsync(loginDto.Email).Result;
            bool userPass = await _userManager.CheckPasswordAsync(user,loginDto.Password);
            if (user == null || !userPass)
            {
                return BadRequest("User not found");
            }
            var result = await _authenticationService.CreateTokenAsync(loginDto);


            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(string token)

        {
            var result = await _authenticationService.CreateTokenByRefreshToken(token);

            return Ok(result);
        }
    }
}
