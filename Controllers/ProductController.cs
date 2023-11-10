using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Repository;

namespace ProductApi.Controllers
{

    [Route("/api/products")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository repository;

        public ProductController(IUnitOfWork unitOfWork, IProductRepository repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await repository.GetProductsAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var result = await repository.GetProductAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostGuid([FromBody] Product product)
        {
            if (product.Price <= 0)
                ModelState.AddModelError(nameof(product.Price), "Price is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await repository.AddProductAsync(product);
            await unitOfWork.CompleteAsync();


            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            if (product == null)
                ModelState.AddModelError(nameof(product), "Product property is required");

            var idNull = new Guid();
            if (product.Id == idNull)
                ModelState.AddModelError(nameof(product.Id), "Id is required");


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dbProduct = await repository.UpdateProductAsync(product);

            if (dbProduct == null)
                return NotFound();

            await unitOfWork.CompleteAsync();

            return Ok(dbProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await repository.RemoveProductAsync(id);

            if (!result)
                return NotFound("Product not found");

            await unitOfWork.CompleteAsync();

            return Ok();
        }
    }



}


