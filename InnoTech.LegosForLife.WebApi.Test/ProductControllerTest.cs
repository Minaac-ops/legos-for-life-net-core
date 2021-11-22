using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InnoTech.LegosForLife.Core.IService;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.WebApi.Controllers;
using InnoTech.LegosForLife.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace InnoTech.LegosForLife.WebApi.Test
{
    public class ProductControllerTest
    {
        #region Controller Intialization

        [Fact]
        public void ProductController_HasProductService_IsOfTypeControllerBase()
        {
            var service = new Mock<IProductService>();
            var controller = new ProductsController(service.Object);
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }

        [Fact]
        public void ProductsController_WithNullProductService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new ProductsController(null));
        }

        [Fact]
        public void ProductsController_WithNullProductRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new ProductsController(null));
            Assert.Equal("ProductService cannot be null", exception.Message);
        }

        [Fact]
        public void ProductController_UsesApiControllerAttribute()
        {
            //Arrange
            var typeInfo = typeof(ProductsController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("ApiControllerAttribute"));
            //Assert
            Assert.NotNull(attr);
        }

        [Fact]
        public void ProductController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            //Arrange
            var typeInfo = typeof(ProductsController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("RouteAttribute"));
            //Assert
            Assert.NotNull(attr);
            var routeAttr = attr as RouteAttribute;
            Assert.Equal("api/[controller]", routeAttr.Template);
        }

        #endregion
        

        #region ReadAllMethod
        
        [Fact]
        public void ProductsController_HasReadAllMethod()
        {
            var method = typeof(ProductsController)
                .GetMethods().FirstOrDefault(m => "ReadAll".Equals(m.Name));
            Assert.NotNull(method);
        }

        [Fact]
        public void ProductsController_HasReadAllMethod_IsPublic()
        {
            var method = typeof(ProductsController)
                .GetMethods().FirstOrDefault(m => "ReadAll".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        [Fact]
        public void ProductsController_HasReadAllMethod_ReturnsListOfProductsDtoInActionResult()
        {
            var method = typeof(ProductsController)
                .GetMethods().FirstOrDefault(m => "ReadAll".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<ProductsDto>).FullName, method.ReturnType.FullName);
        }
        
        [Fact]
        public void ProductsController_ReadAllMethod_HasGetHttpAttribute()
        {
            var methodInfo = typeof(ProductsController)
                .GetMethods()
                .FirstOrDefault(m => m.Name == "ReadAll");
            var attr = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
                
            Assert.NotNull(attr);
        }

        [Fact]
        public void ReadAll_CallsServicesGetProducts_Once()
        {
            //Arrange
            var mockService = new Mock<IProductService>();
            var controller = new ProductsController(mockService.Object);
            
            //Act
            controller.ReadAll();
            
            //Assert
            mockService.Verify(s => s.GetProducts(), Times.Once);
        }
        
        #endregion
        

        #region Post Method
        
        #endregion
    }
}