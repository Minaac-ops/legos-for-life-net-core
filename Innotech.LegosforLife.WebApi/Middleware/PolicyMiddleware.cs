using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InnoTech.LegosForLife.Security;
using InnoTech.LegosForLife.Security.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InnoTech.LegosForLife.WebApi.Middleware
{
    public class PolicyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        
        public PolicyMiddleware(
            RequestDelegate next, 
            IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IAuthService service)
        {

            var user = context.User;
            if (user.Identity is { IsAuthenticated: true })
            {
                var permissionsIdentity = new ClaimsIdentity(nameof(PolicyMiddleware), "name", "role");
                
                //Todo use auth service to get claims 
                permissionsIdentity.AddClaims(new List<Claim>
                {
                    new Claim("permissions", "ProductsReader"), 
                    new Claim("permissions", "ProfileReader")
                });

                user.AddIdentity(permissionsIdentity);
            }
            
            await _next(context);
        }
    }
}