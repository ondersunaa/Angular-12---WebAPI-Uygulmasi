using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KargoAPI.Core.Dtos;
using KargoAPI.Core.Models;
using KargoAPI.Core.Repository;
using KargoAPI.Core.Services;
using KargoAPI.Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace KargoAPI.Service.Services
{
    public class AutheticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserRefreshToken> _userRefreshTokenService;

        public AutheticationService(ITokenService tokenService, UserManager<UserApp> userManager, IUnitOfWork unitOfWork, IRepository<UserRefreshToken> userRefreshTokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = userRefreshTokenService;
        }
        public async Task<TokenReturn> CreateTokenAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            var token = _tokenService.CreateToken(user);
            var userRefreshToken =
                await _userRefreshTokenService.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();
            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenTime });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenTime;
            }

            await _unitOfWork.CommmitAsync();
            return token;
        }

        public async Task<TokenReturn> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            var tokenDto = _tokenService.CreateToken(user);
            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenTime;
            await _unitOfWork.CommmitAsync();
            return tokenDto;
        }
    }
}
