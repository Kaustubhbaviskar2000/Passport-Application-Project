using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IServiceRequiredRepository : IRepository<ServiceRequired>
    {
        Task<ServiceRequired> AddServiceRequiredAsync(ServiceRequired serviceRequired);
    }
}
