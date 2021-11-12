using System.Collections.Generic;
using System.IO;
using System.Linq;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.DataAccess.Entities;
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
            return _ctx.Products.Select(pe => new Product
            {
                Name = pe.Name,
                Id = pe.Id,
                OwnerId = pe.OwnerId
            })
                .ToList();
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

        public Product FindBy(string field, int id)
        {
            var pe = _ctx.Products.FirstOrDefault(p => p.Id == id);
            return pe != null ? new Product
            {   
                Name = pe.Name,
                Id = pe.Id,
                OwnerId = pe.OwnerId
            } : null;
        }

        public Product Update(Product product)
        {
            var pe = _ctx.Update(new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                OwnerId = product.OwnerId
            }).Entity;
            _ctx.SaveChanges();
            return new Product
            {
                Id = pe.Id,
                Name = pe.Name,
                OwnerId = pe.OwnerId
            };
        }
    }
}