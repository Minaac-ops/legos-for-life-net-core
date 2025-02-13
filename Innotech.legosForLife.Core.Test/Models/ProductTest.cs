using System;
using InnoTech.LegosForLife.Core.Models;
using Xunit;

namespace InnoTech.LegosForLife.Core.Test.Models
{
    public class ProductTest
    {
        private readonly Product _product;
        public ProductTest()
        {
            _product = new Product();
        }
        
        [Fact]
        public void Product_CanBeInitialized()
        {
            Assert.NotNull(_product);
        }
        
        [Fact]
        public void Product_Id_MustBeInt()
        {
            Assert.True(_product.Id is int);
        }

        [Fact]
        public void Product_SetId_StoresId()
        {
            _product.Id = 1;
            Assert.Equal(1, _product.Id);
        }
        
        [Fact]
        public void Product_UpdateId_StoresId()
        {
            _product.Id = 1;
            _product.Id = 2;
            Assert.Equal(2, _product.Id);
        }

        [Fact]
        public void Product_setName_StoreNameAsString()
        {
            _product.Name = "LegoBrick";
            Assert.Equal("LegoBrick", _product.Name);
        }
        
        
    }
}