using McDonalds.DataAcces.DTO_s.LoginDto_s;
using McDonalds.DataAcces.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.DataAcces.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> userManager;
        private readonly IConfiguration configuration;
        private ApiUser user;

        public AuthManager(UserManager<ApiUser> user, IConfiguration config)
        {
            userManager = user;
            configuration = config;
        }
        public async Task<string> CreateToken()
        {
            var singInCredentials = GetSignInCredentials();

            var claims = await GetClaims();

            var token = GenerateTokenOptions(singInCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials singInCredentials, List<Claim> claims)
        {
            var jwtSections = configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(
                Convert.ToDouble(
                    jwtSections.GetSection("lifetime").Value));
            var token = new JwtSecurityToken(
                issuer: jwtSections.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: singInCredentials
                );
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", $"{user.FirstName} {user.LastName}")
            };

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private SigningCredentials GetSignInCredentials()
        {
            var key = configuration.GetSection("Jwt").GetSection("Key").Value;

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }


        public async Task<bool> ValidateUser(LoginDto dto)
        {
            user = await userManager.FindByNameAsync(dto.UserName);

            var validPassword = await userManager.CheckPasswordAsync(user, dto.Password);

            return (user != null && validPassword);
        }

    }
}
