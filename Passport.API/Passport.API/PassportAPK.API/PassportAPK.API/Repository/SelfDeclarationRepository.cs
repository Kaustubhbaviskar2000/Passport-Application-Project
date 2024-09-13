using PassportAPK.API.Data;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class SelfDeclarationRepository : Repository<SelfDeclaration> , ISelfDeclarationRepository
    {
        private readonly AppDbContext _context;

        public SelfDeclarationRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<SelfDeclaration> AddSelfDeclarationAsync(SelfDeclaration selfDeclaration)
        {
            await _context.SelfDeclarations.AddAsync(selfDeclaration);
            await _context.SaveChangesAsync();
            return selfDeclaration;
        }
    }
}
