namespace PassportAPK.API.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> AddAsync(T entity);

        Task<T> GetById(int id);  

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity); 
    }
}
