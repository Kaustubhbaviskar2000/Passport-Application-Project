using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLoginId(string loginId);
    }
}
