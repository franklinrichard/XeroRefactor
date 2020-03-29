using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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



        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _productService.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(string id)
        {
            var products = await _productService.GetProducts(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(string id, Products products)
        {
            if (String.Compare(id, products.Id, true) != 0)
            {
                return BadRequest();
            }
            return await _productService.PutProducts(id, products);

        }

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            await _productService.PostProducts(products);

            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
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
