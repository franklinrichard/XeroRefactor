using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace XeroRefactor.Repositories
{
    public class ProductOptionRepository :ControllerBase, IProductOptionsRepository
    {
        private readonly productsContext _context;
        public ProductOptionRepository(productsContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<ProductOptions>> DeleteProductOptions(string id)
        {
            var productOptions = await _context.ProductOptions.FindAsync(id);
            if (productOptions == null)
            {
                return NotFound();
            }

            _context.ProductOptions.Remove(productOptions);
            await _context.SaveChangesAsync();

            return productOptions;
        }

        public async Task<ActionResult<IEnumerable<ProductOptions>>> GetProductOptions()
        {
            return await _context.ProductOptions.ToListAsync();
        }

        public async Task<ActionResult<ProductOptions>> GetProductOptions(string id)
        {
            var productOptions = await _context.ProductOptions.FindAsync(id);

            if (productOptions == null)
            {
                return NotFound();
            }

            return productOptions;
        }

        public async Task<ActionResult<ProductOptions>> PostProductOptions(ProductOptions productOptions)
        {
            _context.ProductOptions.Add(productOptions);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductOptionsExists(productOptions.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductOptions", new { id = productOptions.Id }, productOptions);
        }

        public bool ProductOptionsExists(string id)
        {
            return _context.ProductOptions.Any(e => e.Id == id);
        }

        public async  Task<IActionResult> PutProductOptions(string id, ProductOptions productOptions)
        {
            if (id != productOptions.Id)
            {
                return BadRequest();
            }

            _context.Entry(productOptions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOptionsExists(id))
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
