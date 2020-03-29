using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XeroRefactor;
using XeroRefactor.Services;

namespace XeroRefactor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionsController : ControllerBase
    {
        //private readonly productsContext _context;
        private readonly IProductOptionsService _productOptionsService;

        public ProductOptionsController(IProductOptionsService productOptionsService)
        {
            _productOptionsService = productOptionsService;
        }

        // GET: api/ProductOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOptions>>> GetProductOptions()
        {
            return await _productOptionsService.GetProductOptions();
            //return await _context.ProductOptions.ToListAsync();
        }

        // GET: api/ProductOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOptions>> GetProductOptions(string id)
        {

            var productOptions = await _productOptionsService.GetProductOptions(id);

            if (productOptions == null)
            {
                return NotFound();
            }

            return productOptions;
        }

        // PUT: api/ProductOptions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductOptions(string id, ProductOptions productOptions)
        {
            if (id != productOptions.Id)
            {
                return BadRequest();
            }

            return await _productOptionsService.PutProductOptions(id, productOptions);
            //_context.Entry(productOptions).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProductOptionsExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/ProductOptions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProductOptions>> PostProductOptions(ProductOptions productOptions)
        {
             await _productOptionsService.PostProductOptions(productOptions);
            //_context.ProductOptions.Add(productOptions);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (ProductOptionsExists(productOptions.Id))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return CreatedAtAction("GetProductOptions", new { id = productOptions.Id }, productOptions);
        }

        // DELETE: api/ProductOptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductOptions>> DeleteProductOptions(string id)
        {
            return await _productOptionsService.DeleteProductOptions(id);
            //var productOptions = await _context.ProductOptions.FindAsync(id);
            //if (productOptions == null)
            //{
            //    return NotFound();
            //}

            //_context.ProductOptions.Remove(productOptions);
            //await _context.SaveChangesAsync();

            //return productOptions;
        }

        private bool ProductOptionsExists(string id)
        {
            return _productOptionsService.ProductOptionsExists(id);
            //return _context.ProductOptions.Any(e => e.Id == id);
        }
    }
}
