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
    public class ProductOptionService_Test
    {

        [TestMethod]
        public void ProductOptionService_Should_return_Data_Get()
        {
            //var mockProductRepository = new Mock<IProductRepository>();
            var mockProductOptionsRepository = new Mock<IProductOptionsRepository>();
            IProductOptionsService dataService = new ProductOptionService( mockProductOptionsRepository.Object);
            var mockProductOptions = new ProductOptions();
            mockProductOptions.Id = "1234";
            mockProductOptions.Name = "qwert";
            mockProductOptions.ProductId = "123";
            mockProductOptions.Description = "asdf";
            List<ProductOptions> listProd = new List<ProductOptions>();
            listProd.Add(mockProductOptions);
            ActionResult<IEnumerable<ProductOptions>> productOptions = listProd;
            mockProductOptionsRepository.Setup(a => a.GetProductOptions()).Returns(Task.FromResult(productOptions));
            var actualResult = dataService.GetProductOptions();
            Assert.AreEqual(productOptions.GetType(), actualResult.Result.GetType());
        }

        [TestMethod]
        public void ProductOptionService_Should_return_Data_Get_WithId()
        {
            var mockProductOptionsRepository = new Mock<IProductOptionsRepository>();
            IProductOptionsService dataService = new ProductOptionService(mockProductOptionsRepository.Object);
            var mockProductOptions = new ProductOptions();
            mockProductOptions.Id = "1234";
            mockProductOptions.Name = "qwert";
            mockProductOptions.ProductId = "123";
            mockProductOptions.Description = "asdf";
            //List<ProductOptions> listProd = new List<ProductOptions>();
            //listProd.Add(mockProductOptions);
            ActionResult<ProductOptions> productOptions = mockProductOptions;
            mockProductOptionsRepository.Setup(a => a.GetProductOptions("")).Returns(Task.FromResult(productOptions));
            var actualResult = dataService.GetProductOptions("");
            Assert.AreEqual(productOptions.GetType(), actualResult.Result.GetType());
        }
    }
}

