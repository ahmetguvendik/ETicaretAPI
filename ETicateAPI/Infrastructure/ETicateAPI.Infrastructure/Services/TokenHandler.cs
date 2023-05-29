using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Services;
using Microsoft.IdentityModel.Tokens;

namespace ETicateAPI.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        public Token CreateAccesToken()
        {
            Token token = new Token();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("You_Need_To_Provide_A_Longer_Secret_Key_Here"));
            var signingCredientails = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            token.ExpinationTime = DateTime.UtcNow.AddMinutes(15);
            JwtSecurityToken securityToken = new(
                audience: "www.bilmemne.com",
                issuer: "www.myapi.com",
                expires: token.ExpinationTime,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredientails
                );

            JwtSecurityTokenHandler handler = new();
            token.AccessToken = handler.WriteToken(securityToken);
            return token;
        }
    }
}

