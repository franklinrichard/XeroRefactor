using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XeroRefactor.Services
{
    public interface IProductService
    {
        
        Task<ActionResult<Products>> DeleteProducts(string id);
        Task<IEnumerable<Products>> GetProducts();
        Task<ActionResult<Products>> GetProducts(string id);
        Task<ActionResult<Products>> PostProducts(Products products);
        Task<IActionResult> PutProducts(string id, Products products);
        bool ProductsExists(string id);

    }
}
