using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KargoAPI.Core.Dtos;
using KargoAPI.Core.Models;

namespace KargoAPI.Core.Services
{
   public interface IUserService
   {
       Task<CreateReturnUserDto> CreateUser(CreateUserDto createUserDto);
       Task<UserApp> UserGetByName(string userName);
   }
}
