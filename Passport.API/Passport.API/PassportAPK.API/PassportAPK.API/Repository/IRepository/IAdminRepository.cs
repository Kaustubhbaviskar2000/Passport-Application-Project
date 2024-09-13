using Microsoft.AspNetCore.Mvc;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IAdminRepository : IRepository<User>
    {
        Task<IEnumerable<Feedback>> GetAllFeedback();

        Task<IEnumerable<User>> GetAllUsers();  

        Task<IEnumerable<Feedback>> GetAllComplaints();

        Task<Feedback> GetComplentById(int id);

        Task UpdateComplaint(int id,FeedbackDTO feedback);

        Task DeleteUserComplaint(int id);

        Task<User> GetUserById(int id);

        Task UpdateUser(int id, UserDTO userDTO);
        Task DeleteUser(int id);

        Task<IEnumerable<UpdatePassportDataDTO>> GetNewPassportData();
        Task<IEnumerable<UpdatePassportDataDTO>> GetReNewPassportData();
        Task<UpdatePassportDataDTO> GetNewPassportDataById(int id);
        Task UpdateNewPassport(int id, UpdatePassportDataDTO updatePassportDataDTO);
        Task UpdateReNewPassport(int id, UpdatePassportDataDTO updatePassportDataDTO);

    }
}
