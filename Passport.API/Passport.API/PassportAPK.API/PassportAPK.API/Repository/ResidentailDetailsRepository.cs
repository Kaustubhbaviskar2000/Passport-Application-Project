using PassportAPK.API.Data;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class ResidentailDetailsRepository : Repository<ResidentailDetails>, IResidentailDetailsRepository
    {
        private readonly AppDbContext _context;

        public ResidentailDetailsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ResidentailDetails> AddResidentialDetailAsync(ResidentailDetails residentailDetails)
        {
            await _context.ResidentailDetails.AddAsync(residentailDetails);
            await _context.SaveChangesAsync();
            return residentailDetails;
        }
    }
}
