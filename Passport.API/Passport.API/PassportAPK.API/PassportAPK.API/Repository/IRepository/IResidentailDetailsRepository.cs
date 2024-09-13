using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IResidentailDetailsRepository : IRepository<ResidentailDetails>
    {
        Task<ResidentailDetails> AddResidentialDetailAsync(ResidentailDetails residentailDetails);
    }
}
