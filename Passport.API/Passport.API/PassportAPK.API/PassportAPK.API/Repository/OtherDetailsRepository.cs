using PassportAPK.API.Data;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class OtherDetailsRepository : Repository<OtherDetails> , IOtherDetailsRepository
    {
        private readonly AppDbContext _context;

        public OtherDetailsRepository(AppDbContext context) : base (context)
        {
            _context = context;
        }

        public async Task<OtherDetails> AddOtherDetailsAsync(OtherDetails otherDetails)
        {
            await _context.OtherDetails.AddAsync(otherDetails);
            await _context.SaveChangesAsync();
            return otherDetails;
        }
    }
}
