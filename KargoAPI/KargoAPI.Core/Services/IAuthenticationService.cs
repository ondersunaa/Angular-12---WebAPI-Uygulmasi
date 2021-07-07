using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KargoAPI.Core.Dtos;

namespace KargoAPI.Core.Services
{
   public interface IAuthenticationService
    {
        Task<TokenReturn> CreateTokenAsync(LoginDto loginDto);

        Task<TokenReturn> CreateTokenByRefreshToken(string refreshToken);
    }
}
