namespace TunifyPlatform.Repositories.Interfaces
{
   
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        // IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
    }

}
