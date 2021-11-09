using System.Collections.Generic;
using System.IO;
using System.Linq;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Domain.IRepositories;

namespace InnoTech.LegosForLife.DataAccess.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly MainDbContext _ctx;

        public ProductRepository(MainDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Product Repository Must have a DBContext");
            _ctx = ctx;
        }
        public List<Product> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Product> ReadMyProducts(int userId)
        {
            return _ctx.Products.Where(p => p.OwnerId == userId)
                .Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();
        }
    }
}