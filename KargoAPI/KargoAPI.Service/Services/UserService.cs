using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KargoAPI.Core.Dtos;
using KargoAPI.Core.Models;
using KargoAPI.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace KargoAPI.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;

        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }
        public async Task<CreateReturnUserDto> CreateUser(CreateUserDto createUserDto)
        {
            CreateReturnUserDto returnUser = new CreateReturnUserDto();
            returnUser.CreateUserDto = createUserDto;
            returnUser.Ok = true;
            var user = new UserApp {Email = createUserDto.Email, UserName = createUserDto.UserName};
            var result = _userManager.CreateAsync(user, createUserDto.Password);
            if (!result.Result.Succeeded)
            {
                var errors = result.Result.Errors.Select(x => x.Description).ToList();
                returnUser.CreateUserDto = createUserDto;
                returnUser.Ok = false;
                returnUser.ErrorList = errors;
                return returnUser;
            }

            return returnUser;
        }

        public async Task<UserApp> UserGetByName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return null;
            return user;
        }
    }
}
