using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeroRefactor.Repositories;

namespace XeroRefactor.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IProductOptionsRepository _productOptionsRepository;

        public ProductService(IProductRepository ProductRepository, IProductOptionsRepository productOptionsRepository)
        {
            _productRepository = ProductRepository;
            _productOptionsRepository = productOptionsRepository;
        }

        public Task<ActionResult<Products>> DeleteProducts(string id)
        {
            _productOptionsRepository.DeleteProductOptions(id);
            return _productRepository.DeleteProducts(id);

        }

        public Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Task<ActionResult<Products>> GetProducts(string id)
        {
            return _productRepository.GetProducts(id);
        }

        public Task<ActionResult<Products>> PostProducts(Products products)
        {
            return _productRepository.PostProducts(products);
        }

        public bool ProductsExists(string id)
        {
            return _productRepository.ProductsExists(id);
        }

        public Task<IActionResult> PutProducts(string id, Products products)
        {
            return _productRepository.PutProducts(id, products);
        }
       
    }
}
