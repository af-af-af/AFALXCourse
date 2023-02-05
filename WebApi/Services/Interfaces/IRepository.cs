namespace WebApi.Services.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid Id);
        Task<List<T>> GetAll();
        Task Create(T entity);
    }
}
