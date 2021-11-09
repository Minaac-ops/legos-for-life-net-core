using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using InnoTech.LegosForLife.Security.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InnoTech.LegosForLife.Security.Services
{
    public class AuthService: IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool IsValidUserInformation(LoginUser user)
        {
            return user.UserName.Equals("ljuul") && user.Password.Equals("123456");
        }

        /// <summary>
        /// Generate JWT Token after successful login.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public string GenerateJwtToken(LoginUser user)
        {
            if (!IsValidUserInformation(user)) return null;
           
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Id", user.Id.ToString()), new Claim("UserName", user.UserName) }),
                Expires = DateTime.UtcNow.AddDays(14),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool UserHasPermission(LoginUser user, string permission)
        {
            return user.Permissions.Exists(p => p.Name.Equals(permission));
        }

        public int GetUserId()
        {
            return 1;
        }
    }
}