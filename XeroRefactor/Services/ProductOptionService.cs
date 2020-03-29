using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeroRefactor.Repositories;

namespace XeroRefactor.Services
{
    public class ProductOptionService : IProductOptionsService
    {
        private readonly IProductOptionsRepository _productOptions;

        public ProductOptionService(IProductOptionsRepository productOptions)
        {
            _productOptions = productOptions;
        }


        public Task<ActionResult<ProductOptions>> DeleteProductOptions(string id)
        {
            return _productOptions.DeleteProductOptions(id);
        }

        public Task<ActionResult<IEnumerable<ProductOptions>>> GetProductOptions()
        {
            return _productOptions.GetProductOptions();
        }

        public Task<ActionResult<ProductOptions>> GetProductOptions(string id)
        {
            return _productOptions.GetProductOptions(id);
        }

        public Task<ActionResult<ProductOptions>> PostProductOptions(ProductOptions productOptions)
        {
            return _productOptions.PostProductOptions(productOptions);
        }

        public bool ProductOptionsExists(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> PutProductOptions(string id, ProductOptions productOptions)
        {
            return _productOptions.PutProductOptions(id, productOptions);
        }
    }
}
