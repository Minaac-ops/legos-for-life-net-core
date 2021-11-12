using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Domain.IRepositories
{
    public interface IProductRepository
    {
        List<Product> FindAll();
        List<Product> ReadMyProducts(int userId);
        Product FindBy(string field, int id);
        Product Update(Product product);
    }
}