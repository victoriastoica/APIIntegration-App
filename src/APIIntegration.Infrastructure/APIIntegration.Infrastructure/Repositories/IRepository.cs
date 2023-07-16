namespace APIIntegration.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAsync();
        Task<T?> GetByIdAsync(int id);
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> SoftDeleteAsync(int id);
    }
}
