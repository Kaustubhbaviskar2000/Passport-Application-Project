using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IJWTTokenService
    {
        Task<string> GenerateToken(ApplicationUser userData);
    }
}
