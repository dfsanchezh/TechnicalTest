using ApiAmarisCore.ICore;
using ApiAmarisDto.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace ApiAmarisCore.Core
{
    public class AuthenticationCore : IAuthenticationCore
    {
        private readonly IConfiguration _configuration;

        public AuthenticationCore(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenJwtDTO GetAuthentication()
        {
            
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var time = _configuration.GetValue<int>("AmarisSettings:Jwt:MinutesExpired");
            var Secret = _configuration.GetValue<string>("AmarisSettings:Jwt:Secret");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            DateTime expiration = DateTime.Now.AddMinutes(time);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );

            TokenJwtDTO tokenJwtDTO = new TokenJwtDTO();
            tokenJwtDTO.Token = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenJwtDTO;
       

        }
    }
}
