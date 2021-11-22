using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Domain.IRepositories;
using IProductService = InnoTech.LegosForLife.Core.IService.IProductService;

namespace InnoTech.LegosForLife.Domain.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new InvalidDataException("ProductRepository Cannot Be Null");
        }
        public List<Product> GetProducts()
        {
            return _productRepository.FindAll();
        }
    }
}