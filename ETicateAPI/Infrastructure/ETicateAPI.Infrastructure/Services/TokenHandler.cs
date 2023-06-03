using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Services;
using ETicateAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ETicateAPI.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccesToken(AppUser user)
        {
            Token token = new Token();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
            var signingCredientails = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            token.ExpinationTime = DateTime.UtcNow.AddMinutes(15);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.ExpinationTime,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredientails,
                claims: new List<Claim> { new(ClaimTypes.Name,user.UserName)}
                );

            JwtSecurityTokenHandler handler = new();
            token.AccessToken = handler.WriteToken(securityToken);
            return token;
        }
    }
}

