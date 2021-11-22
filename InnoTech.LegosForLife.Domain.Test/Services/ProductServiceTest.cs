using System;
using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.IService;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Domain.IRepositories;
using InnoTech.LegosForLife.Domain.Services;
using Moq;
using Xunit;

namespace InnoTech.LegosForLife.Domain.Test.Services
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _mock;
        private readonly ProductService _service;
        private readonly List<Product> _expected;

        public ProductServiceTest()
        {
            _mock = new Mock<IProductRepository>();
            _service = new ProductService(_mock.Object);
            _expected = new List<Product>
            {
                new Product {Id = 1, Name = "Lego1"},
                new Product {Id = 2, Name = "Lego2"}
            };
        }

        [Fact]
        public void IProductRepository_Exists()
        {
            Assert.NotNull(_mock.Object);
        }

        [Fact]
        public void ReadAll_WithNoParams_ReturnsListOfProducts()
        {
            _mock.Setup(r => r.FindAll())
                .Returns(new List<Product>());
            Assert.NotNull(_mock.Object.FindAll());
        }
        
        [Fact]
        public void ProductService_IsIProductService()
        {
            Assert.True(_service is IProductService);
        }

        [Fact]
        public void ProductService_WithNullProductRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new ProductService(null)
            );
        }

        [Fact]
        public void ProductService_WithNullProductRepository_ThrowsInvalidExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new ProductService(null)
            );
            Assert.Equal("ProductRepository cannot be null.", actual: exception.Message);
        }

        [Fact]
        public void GetProducts_CallsProductRepositoriesFindAll_ExactlyOnce()
        {
            _service.GetProducts();
            _mock.Verify(r => r.FindAll(), Times.Once);
        }

        [Fact]
        public void GetProducts_NoFilter_ReturnsListOfAllProducts()
        {
            _mock.Setup(r => r.FindAll())
                .Returns(_expected);
            var actual = _service.GetProducts();
            Assert.Equal(_expected, actual);
            
        }
        
        public class ProductComparer : IEqualityComparer<Product>
        {
            public bool Equals(Product x, Product y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.Name == y.Name;
            }

            public int GetHashCode(Product obj)
            {
                return HashCode.Combine(obj.Id, obj.Name);
            }
        }
    }
}