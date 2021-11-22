using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InnoTech.LegosForLife.Core.IService;
using InnoTech.LegosForLife.WebApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;

        public ProductsController(IProductService productService)
        {
            if (productService == null)
            {
                throw new InvalidDataException("ProductService cannot be null");
            }
            _productsService = productService;
        }
        
        [HttpGet]
        public ActionResult<ProductsDto> ReadAll()
        {
            try
            {
                var products = _productsService.GetProducts()
                    .Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToList();
            
                return Ok(new ProductsDto
                {
                    List = products
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}