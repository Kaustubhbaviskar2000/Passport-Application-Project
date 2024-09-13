using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface ISelfDeclarationRepository : IRepository<SelfDeclaration>
    {
        Task<SelfDeclaration> AddSelfDeclarationAsync(SelfDeclaration selfDeclaration);
    }
}
