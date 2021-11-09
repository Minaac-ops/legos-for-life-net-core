using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IAuthService _authService;

        public ProductsController(IProductService service, IAuthService authService)
        {
            _service = service;
            _authService = authService;
        } 
        
        [PermissionAuthorize]
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var user = _authService.GetUserId();
            return _service.GetProducts();
        }
    }
}