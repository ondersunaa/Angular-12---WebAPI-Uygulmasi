using System;
using System.Collections.Generic;
using System.Text;
using KargoAPI.Core.Dtos;
using KargoAPI.Core.Models;

namespace KargoAPI.Core.Services
{
   public interface ITokenService
   {
       TokenReturn CreateToken(UserApp userApp);


   }
}
