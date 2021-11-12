using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Core.IServices
{
    public interface IProductService
    {
        List<Product> GetProducts();

        List<Product> GetMyProducts(int userId);
        Product GetProduct(int id);
        Product UpdateProduct(Product product);
    }
}