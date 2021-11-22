using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnoTech.LegosForLife.WebApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult<LoginDto> Login([FromBody] LoginDto dto)
        {
            //Peters kode
            if (dto.Username == "nam@hotmail.com" && dto.Password == "ostebolle")
            {
                return Ok(new LoginDto{ Token = "token123"});
            }
            return Unauthorized();
        }
    }
}