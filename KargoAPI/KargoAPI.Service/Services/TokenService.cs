using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using KargoAPI.Core.Dtos;
using KargoAPI.Core.Models;
using KargoAPI.Core.Services;
using KargoAPI.Service.Extension;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KargoAPI.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly GetTokenOptions _getTokenOptions;

        public TokenService(UserManager<UserApp> userManager, IOptions<GetTokenOptions> tokenOptions)
        {
            _userManager = userManager;
            _getTokenOptions = tokenOptions.Value;
        }

        private string CreateRefreshToken()

        {
            var numberByte = new Byte[32];

            using var rnd = RandomNumberGenerator.Create();

            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }
        public TokenReturn CreateToken(UserApp userApp)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_getTokenOptions.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_getTokenOptions.RefreshTokenExpiration);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_getTokenOptions.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var userList = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,userApp.Id),
                new Claim(JwtRegisteredClaimNames.Email, userApp.Email),
                new Claim(ClaimTypes.Name,userApp.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(

                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: userList,
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);
            var tokenDto = new TokenReturn
            {
                Token = token,
                RefreshToken = CreateRefreshToken(),
                TokenTime = accessTokenExpiration,
                RefreshTokenTime = refreshTokenExpiration
            };
            return tokenDto;
        }
    }
}
