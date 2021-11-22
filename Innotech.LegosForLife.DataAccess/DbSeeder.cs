using InnoTech.LegosForLife.DataAccess;
using System.Linq;
using InnoTech.LegosForLife.DataAccess.Entities;


namespace Innotech.LegosForLife.DataAccess
{
    public class DbSeeder
    {
        private readonly MainDbContext _ctx;

        public DbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            _ctx.Products.Add(new ProductEntity{Name = "Lego1"});
            _ctx.Products.Add(new ProductEntity{Name = "Lego2"});
            _ctx.Products.Add(new ProductEntity{Name = "Lego3"});

            _ctx.Products.Add(new ProductEntity{Name = "Product1"});
            _ctx.Products.Add(new ProductEntity{Name = "Product2"});
            _ctx.Products.Add(new ProductEntity{Name = "Product3"});

            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
            var count = _ctx.Products.Count();
            if (count == 0)
            {
                _ctx.Products.Add(new ProductEntity{Name = "Lego1"});
                _ctx.Products.Add(new ProductEntity{Name = "Lego2"});
                _ctx.Products.Add(new ProductEntity{Name = "Lego3"});
                _ctx.SaveChanges();
            }
        }
    }
}