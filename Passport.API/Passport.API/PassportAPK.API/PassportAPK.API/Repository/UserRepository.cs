using Microsoft.EntityFrameworkCore;
using PassportAPK.API.Data;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<User> GetByLoginId(string loginId)
        {
            foreach(var x in _context.Users)
            {
                if(x.LoginId == loginId)
                {
                    return x;
                }
            }
            return null;
        }

        public Task<User> TrackPassportStatus(TrackPassportStatusDTO trackPassportStatusDTO)
        {
            throw new NotImplementedException();
        }
    }
}
