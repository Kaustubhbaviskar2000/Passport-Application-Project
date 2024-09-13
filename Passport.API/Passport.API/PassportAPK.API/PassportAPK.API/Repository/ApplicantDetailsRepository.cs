using PassportAPK.API.Data;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class ApplicantDetailsRepository : Repository<ApplicantDetails>, IApplicantDetailsRepository
    {
        private readonly AppDbContext _context;
        public ApplicantDetailsRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<ApplicantDetails> AddApplicantDetailsAsync(ApplicantDetails applicantDetails)
        {
            await _context.ApplicantDetails.AddAsync(applicantDetails);
            await _context.SaveChangesAsync();
            return applicantDetails;
        }
    }
}
