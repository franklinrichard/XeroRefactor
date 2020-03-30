using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using XeroRefactor;
using XeroRefactor.Repositories;
using XeroRefactor.Services;

namespace XeroRefactor_Tests
{
    [TestClass]
    public class ProductService_Test
    {
        [TestMethod]
        public void ProductService_Should_return_Data_Get()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            var mockProductOptionsRepository = new Mock<IProductOptionsRepository>();
            IProductService dataService = new ProductService(mockProductRepository.Object, mockProductOptionsRepository.Object);
            var mockProduct = new Products();
            mockProduct.Id = "1234";
            mockProduct.Name = "qwert";
            mockProduct.Price = 123;
            mockProduct.Description = "asdf";
            List<Products> listProd = new List<Products>();
            listProd.Add(mockProduct);
            IEnumerable<Products> products = listProd;
            mockProductRepository.Setup(a => a.GetProducts()).Returns(Task.FromResult(products));           
            var actualResult = dataService.GetProducts();
            Assert.AreEqual(products.GetType(), actualResult.Result.GetType());
        }

        [TestMethod]
        public void ProductService_Should_return_Data_Get_WithId()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            var mockProductOptionsRepository = new Mock<IProductOptionsRepository>();
            IProductService dataService = new ProductService(mockProductRepository.Object, mockProductOptionsRepository.Object);
            var mockProduct = new Products();
            mockProduct.Id = "1234";
            mockProduct.Name = "qwert";
            mockProduct.Price = 123;
            mockProduct.Description = "asdf";
            ActionResult<Products> products = mockProduct;
            mockProductRepository.Setup(a => a.GetProducts("123")).Returns(Task.FromResult(products));
            var actualResult = dataService.GetProducts("123");
            Assert.AreEqual(products.GetType(), actualResult.Result.GetType());
        }
    }
}

