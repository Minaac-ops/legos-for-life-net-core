using InnoTech.LegosForLife.Security;
using InnoTech.LegosForLife.Security.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [AllowAnonymous]
        [HttpPost(nameof(Auth))]
        public IActionResult Auth([FromBody] LoginUser user)
        {
            var tokenString = _authService.GenerateJwtToken(user);
            if (string.IsNullOrEmpty(tokenString))
            {
                return BadRequest("Please pass the valid Username and Password");
            }
            return Ok(new { Token = tokenString, Message = "Success" });
        }
        
        [PermissionAuthorize]
        [HttpGet(nameof(GetResult))]
        public IActionResult GetResult()
        {
            var user = HttpContext.Items["LoginUser"] as LoginUser;
            return Ok("API Validated");
        }
        
    }
    
}