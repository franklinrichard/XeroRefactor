using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using XeroRefactor;
using XeroRefactor.Repositories;
using XeroRefactor.Services;

namespace XeroRefactor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly productsContext _context;

        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;



        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;

        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Products>> GetProducts()
        {
            _logger.LogInformation("Get Products");
            return await _productService.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(string id)
        {
            _logger.LogInformation("Get Products for "+ id);
            var products = await _productService.GetProducts(id);

           

            return products;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(string id, Products products)
        {
            
            return await _productService.PutProducts(id, products);

        }

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            return await _productService.PostProducts(products);

           
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(string id)
        {
            return await _productService.DeleteProducts(id);

        }

        private bool ProductsExists(string id)
        {
            return _productService.ProductsExists(id);
            //return _context.Products.Any(e => e.Id == id);
        }
    }
}
