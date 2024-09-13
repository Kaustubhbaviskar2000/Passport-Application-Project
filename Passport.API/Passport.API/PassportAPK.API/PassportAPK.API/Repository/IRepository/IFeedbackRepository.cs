using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Task<Feedback> CreateAsync(Feedback feedback);  
    }
}
