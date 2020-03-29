using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeroRefactor.Repositories;


namespace XeroRefactor.Repositories
{

    public class ProductRepository : ControllerBase,IProductRepository
    {
        private readonly productsContext _context;

        //private readonly IproductsContext _iproductsContext;
        public ProductRepository(productsContext context)
        {
            _context = context;            
        }
        public async Task<ActionResult<Products>> DeleteProducts(string id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return products;

        }

        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            
            return await _context.Products.ToListAsync();
        }

        public async Task<ActionResult<Products>> GetProducts(string id)
        {

            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
              _context.Products.Add(products);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductsExists(products.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
        }

        public bool ProductsExists(string id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public async  Task<IActionResult> PutProducts(string id, Products products)
        {
            if (id != products.Id)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    }
}
