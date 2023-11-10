using ProductApi.Context;

namespace ProductApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext _context;

        public UnitOfWork(ProductDbContext context) => _context = context;


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
