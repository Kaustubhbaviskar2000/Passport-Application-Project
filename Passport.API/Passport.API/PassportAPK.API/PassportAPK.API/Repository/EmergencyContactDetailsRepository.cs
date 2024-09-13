using PassportAPK.API.Data;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class EmergencyContactDetailsRepository : Repository<EmergencyContactDetails> , IEmergencyContactDetailsRepository
    {
        private readonly AppDbContext _context;

        public EmergencyContactDetailsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EmergencyContactDetails> AddEmergencyContactDetailsAsync(EmergencyContactDetails emergencyContactDetails)
        {
            await _context.EmergencyContactDetails.AddAsync(emergencyContactDetails);
            await _context.SaveChangesAsync();
            return emergencyContactDetails;
        }
    }
}
