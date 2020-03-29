using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XeroRefactor.Repositories
{
    public interface IProductOptionsRepository
    {
        Task<ActionResult<ProductOptions>> DeleteProductOptions(string id);
        Task<ActionResult<IEnumerable<ProductOptions>>> GetProductOptions();
        Task<ActionResult<ProductOptions>> GetProductOptions(string id);
        Task<ActionResult<ProductOptions>> PostProductOptions(ProductOptions productOptions);
        Task<IActionResult> PutProductOptions(string id, ProductOptions productOptions);
        bool ProductOptionsExists(string id);
    }
    
}
