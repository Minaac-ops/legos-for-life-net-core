using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Core.IService
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}