namespace ProductApi.Repository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
