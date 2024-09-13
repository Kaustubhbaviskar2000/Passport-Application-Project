using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IApplicantDetailsRepository : IRepository<ApplicantDetails>
    {
        Task<ApplicantDetails> AddApplicantDetailsAsync(ApplicantDetails applicantDetails);
    }
}
