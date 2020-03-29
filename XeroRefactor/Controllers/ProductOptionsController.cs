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
            if (String.Compare(id, productOptions.Id, true) != 0)
            {
                return BadRequest();
            }

            return await _productOptionsService.PutProductOptions(id, productOptions);
            
        }

        // POST: api/ProductOptions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProductOptions>> PostProductOptions(ProductOptions productOptions)
        {
             await _productOptionsService.PostProductOptions(productOptions);
            

            return CreatedAtAction("GetProductOptions", new { id = productOptions.Id }, productOptions);
        }

        // DELETE: api/ProductOptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductOptions>> DeleteProductOptions(string id)
        {
            return await _productOptionsService.DeleteProductOptions(id);
           
        }

        private bool ProductOptionsExists(string id)
        {
            return _productOptionsService.ProductOptionsExists(id);
           
        }
    }
}
