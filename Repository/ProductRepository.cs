using Microsoft.EntityFrameworkCore;
using ProductApi.Context;
using ProductApi.Models;

namespace ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context) => _context = context;


        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Guid> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            return product.Id;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.Id);

            if (dbProduct == null)
                return null;

            dbProduct.Quantity = product.Quantity;
            dbProduct.Description = product.Description;

            return (dbProduct);
        }

        public async Task<bool> RemoveProductAsync(Guid id)
        {
            var dbProduct = await _context.Products.FindAsync(id);

            if (dbProduct == null)
                return false;

            _context.Remove(dbProduct);
            return true;
        }
    }
}
