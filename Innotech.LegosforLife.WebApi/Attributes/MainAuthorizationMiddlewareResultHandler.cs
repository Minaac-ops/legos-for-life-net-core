using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace InnoTech.LegosForLife.Security
{
    public class MainAuthorizationMiddlewareResultHandler: IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler 
            DefaultHandler = new AuthorizationMiddlewareResultHandler();

        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy,
            PolicyAuthorizationResult authorizeResult)
        {
            /*if (Show404ForForbiddenResult(authorizeResult))
            {
                // Return a 404 to make it appear as if the resource does not exist.
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return;
            }*/
            await DefaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
        
        bool Show404ForForbiddenResult(PolicyAuthorizationResult policyAuthorizationResult)
        {
            return policyAuthorizationResult.Forbidden &&
                   policyAuthorizationResult.AuthorizationFailure.FailedRequirements.OfType<
                       Show404Requirement>().Any();
        }
        
        public class Show404Requirement : IAuthorizationRequirement { }
    }
}