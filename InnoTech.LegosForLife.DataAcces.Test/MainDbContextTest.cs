using EntityFrameworkCore.Testing.Moq;
using InnoTech.LegosForLife.DataAccess;
using InnoTech.LegosForLife.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InnoTech.LegosForLife.DataAcces.Test
{
    public class MainDbContextTest
    {
        [Fact]
        public void DbContext_WithDbContextOptions_IsAvailable()
        {
            var mockedDbContext = Create.MockedDbContextFor<MainDbContext>();
            Assert.NotNull(mockedDbContext);
        }

        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeProductEntity()
        {
            var mockedDbContext = Create.MockedDbContextFor<MainDbContext>();
            Assert.True(mockedDbContext.Products is DbSet<ProductEntity>);
        }
    }
}