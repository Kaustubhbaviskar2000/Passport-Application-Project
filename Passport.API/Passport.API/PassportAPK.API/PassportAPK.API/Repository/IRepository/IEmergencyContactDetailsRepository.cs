using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IEmergencyContactDetailsRepository : IRepository<EmergencyContactDetails>
    {
        Task<EmergencyContactDetails> AddEmergencyContactDetailsAsync(EmergencyContactDetails emergencyContactDetails);
    }
}
