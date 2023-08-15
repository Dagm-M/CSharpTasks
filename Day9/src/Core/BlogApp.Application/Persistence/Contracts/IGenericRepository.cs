namespace BlogApp.Application.Persitence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Update(T entity);
        Task<T> Delete(int Id);
    }
}