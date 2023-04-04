using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaggerApi.Models;

namespace SwaggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly FluentValidationFatihCakirogluContext _context;

        public ProductsController(FluentValidationFatihCakirogluContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Bu endpoint tüm ürünleri list olarak geri döner.
        /// </summary>
        /// <remarks>
        /// örnek: https://localhost:44318/api/products
        /// </remarks>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Bu endpoint verilen id ye sahip ürünü döner
        /// </summary>
        /// <param name="id">ürünün id'si</param>
        /// <returns></returns>
        /// <response code="404">verilen id sahip ürün bulunmadı</response>
        /// <response code="200">verilen id'ye sahip ürün vardır</response>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        /// <summary>
        /// Bu endpoinnt ürün ekler
        /// </summary>
        /// <remarks>
        /// Örnek: product json:{"name":"kalem,"price":12,"category":"kirtasiye"}
        /// </remarks>
        /// <param name="product">json product nesnesi</param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json")]

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            product.Date = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
