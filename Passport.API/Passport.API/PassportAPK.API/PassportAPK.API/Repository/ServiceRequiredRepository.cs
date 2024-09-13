using PassportAPK.API.Data;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class ServiceRequiredRepository : Repository<ServiceRequired>, IServiceRequiredRepository
    {
        private readonly AppDbContext _context;
        public ServiceRequiredRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ServiceRequired> AddServiceRequiredAsync(ServiceRequired serviceRequired)
        {
            await _context.ServiceRequireds.AddAsync(serviceRequired);
            await _context.SaveChangesAsync();
            return serviceRequired;
        }
    }
}
