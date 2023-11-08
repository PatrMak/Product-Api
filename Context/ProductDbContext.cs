using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Context
{
    public class ProductDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public ProductDbContext()
        {

        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {

        }
    }
}
