using ProductApi.Models;

namespace ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(Guid id);

        Task<Guid> AddProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product);

        Task<bool> RemoveProductAsync(Guid id);
    }
}