using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IOtherDetailsRepository : IRepository<OtherDetails>
    {
        Task<OtherDetails> AddOtherDetailsAsync(OtherDetails otherDetails); 
    }
}
