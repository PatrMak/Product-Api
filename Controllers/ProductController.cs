using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Context;
using ProductApi.Models;

namespace ProductApi.Controllers
{

    [Route("/api/products")]
    public class ProductController : Controller
    {

        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _context.Products.ToListAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostGuid([FromBody] Product product)
        {
            if (product.Price <= 0)
                ModelState.AddModelError(nameof(product.Price), "Price is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();


            return Ok(product.Id);
        }

    }



}


