using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InnoTech.LegosForLife.Security
{
    public class CanReadProductsRequirement : AuthorizationHandler<CanReadProductsRequirement>, IAuthorizationRequirement
    {
        public int Id { get; set; }
        
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanReadProductsRequirement requirement)
        {
            if (true)
            {
                Id = 12;
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}