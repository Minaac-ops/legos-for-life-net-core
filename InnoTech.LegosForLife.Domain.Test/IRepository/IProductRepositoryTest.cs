using System.Collections.Generic;
using System.Dynamic;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Domain.IRepositories;
using Moq;
using Xunit;

namespace InnoTech.LegosForLife.Domain.Test.IRepository
{
    public class IProductRepositoryTest
    {
        [Fact]
        public void IProductsRepository_Exists()
        {
            var repoMock = new Mock<IProductRepository>();
            Assert.NotNull(repoMock.Object);
        }

        [Fact]
        public void ReadAll_WithNoParams_ReturnsListOfProducts()
        {
            var repoMock = new Mock<IProductRepository>();
            repoMock
                .Setup(r => r.FindAll())
                .Returns(new List<Product>());
            Assert.NotNull(repoMock.Object.FindAll());
        }

    }
}