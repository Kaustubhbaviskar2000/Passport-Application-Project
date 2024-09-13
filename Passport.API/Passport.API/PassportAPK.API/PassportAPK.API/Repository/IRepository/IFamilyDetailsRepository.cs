using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IFamilyDetailsRepository : IRepository<FamilyDetails>
    {
        Task<FamilyDetails> AddFamilyDetailsAsync(FamilyDetails familyDetails);  
    }
}
