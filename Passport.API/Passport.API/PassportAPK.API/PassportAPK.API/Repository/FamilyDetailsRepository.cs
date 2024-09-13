using PassportAPK.API.Data;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class FamilyDetailsRepository : Repository<FamilyDetails> , IFamilyDetailsRepository
    {
        private readonly AppDbContext _context;

        public FamilyDetailsRepository(AppDbContext context) : base (context)
        {
            _context  = context;
        }

        public async Task<FamilyDetails> AddFamilyDetailsAsync(FamilyDetails familyDetails)
        {
            await _context.FamilyDetails.AddAsync(familyDetails);
            await _context.SaveChangesAsync();
            return  familyDetails;
        }
    }
}
