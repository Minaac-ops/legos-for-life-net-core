using System.Linq;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.WebApi.Dtos.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        
        public ProductsController(IProductService service)
        {
            _service = service;
        } 
        
        [Authorize(Policy = "ProductsReader")]
        [HttpGet]
        public ActionResult<ProductsAllDto> Get()
        {
            var list = _service.GetProducts()
                .Select(p => new ProductDto{Id = p.Id, Name = p.Name, OwnerId = p.OwnerId})
                .ToList();
            return Ok(new ProductsAllDto { List = list });
        }
        
        [Authorize(Policy = "ProductsReader")]
        [HttpGet("{id:int}")]
        public ActionResult<ProductDto> Get(int id)
        {
            var product = _service.GetProduct(id);
            return Ok(new ProductDto { Id = product.Id, Name = product.Name, OwnerId = product.OwnerId});
        }
        
        [Authorize(Policy = "ProductsManager")]
        [HttpPut("{id:int}")]
        public ActionResult<ProductDto> Put(int id, ProductDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Ids dont match");
            }
            var product = _service.UpdateProduct(new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                OwnerId = dto.OwnerId
            });
            return Ok(dto);
        }
    }
}