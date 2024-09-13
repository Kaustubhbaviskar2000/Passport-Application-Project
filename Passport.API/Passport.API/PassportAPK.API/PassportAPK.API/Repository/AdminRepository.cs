using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PassportAPK.API.Data;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class AdminRepository : Repository<User>, IAdminRepository
    {
        private readonly AppDbContext _contex;
        public AdminRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _contex = appDbContext;
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                User user = await _contex.Users.FindAsync(id);
                if (user != null)
                {
                    _contex.Users.Remove(user);
                    await _contex.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public async Task DeleteUserComplaint(int id)
        {
            Feedback filteredFeedback = await _contex.Feedbacks.FindAsync(id);
            if(filteredFeedback != null)
            {
                try
                {
                    _contex.Feedbacks.Remove(filteredFeedback);
                    await _contex.SaveChangesAsync();
                }
                catch(Exception ex)
                {

                }
            }
        }

        public async Task<IEnumerable<Feedback>> GetAllComplaints()
        {
            IEnumerable<Feedback> feedbackList = await _contex.Feedbacks.ToListAsync();
            IEnumerable<Feedback> filteredFeedbackList = feedbackList.Where(feedback => feedback.FeedbackType == "Complaint");
            return filteredFeedbackList;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedback()
        {
            IEnumerable<Feedback> feedbackList =  await _contex.Feedbacks.ToListAsync();
            IEnumerable<Feedback> filteredFeedbackList =  feedbackList.Where(feedback => feedback.FeedbackType == "Feedback");
            return filteredFeedbackList;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            IEnumerable<User> userList = await _contex.Users.ToListAsync();
            return userList; 
        }

        public async Task<Feedback> GetComplentById(int id)
        {
            Feedback GetUserFeedback = await _contex.Feedbacks.FindAsync(id);
            return GetUserFeedback;
        }
        public async Task<UpdatePassportDataDTO> GetNewPassportDataById(int id)
        {
            return  await _contex.MasterDetailsTables
                .Where(x => x.MasterDetailsId == id)
                .Include(s => s.ServiceRequired)
                .Include(a => a.ApplicantDetails)
                .Select(item => new UpdatePassportDataDTO
                {
                    MasterDetailsId = item.MasterDetailsId,
                    FirstName = item.ApplicantDetails.FirstName,
                    LastName = item.ApplicantDetails.LastName,
                    PassportApplicationStatus = item.PassportApplicationStatus,
                    PassportNumber = item.PassportNumber,
                    ApplicationType = item.ServiceRequired.ApplicationType,
                    PaymentStatus = item.PaymentStatus,
                    PassportType = item.PassportType
                }).FirstOrDefaultAsync()
                ;
        }
        public async Task<IEnumerable<UpdatePassportDataDTO>> GetNewPassportData()
        {
            var result = await _contex.MasterDetailsTables
                .Where(x => x.PassportType == "New")
                .Include(s => s.ServiceRequired)
                .Include(a => a.ApplicantDetails)
                .Select(item => new UpdatePassportDataDTO
                {
                    MasterDetailsId = item.MasterDetailsId,
                    FirstName = item.ApplicantDetails.FirstName,
                    LastName = item.ApplicantDetails.LastName,
                    PassportApplicationStatus = item.PassportApplicationStatus,
                    PassportNumber = item.PassportNumber,
                    ApplicationType = item.ServiceRequired.ApplicationType,
                    PaymentStatus = item.PaymentStatus,
                    PassportType = item.PassportType
                })
                .ToListAsync(); 

            return result;
        }

        public async Task<IEnumerable<UpdatePassportDataDTO>> GetReNewPassportData()
        {
            
            return await _contex.MasterDetailsTables.Where(user => user.PassportType == "ReNew")
                                       .Include(s => s.ServiceRequired)
                                       .Include(a => a.ApplicantDetails)
                                       .Select(item => new UpdatePassportDataDTO()
                                       {
                                           MasterDetailsId = item.MasterDetailsId,
                                           FirstName = item.ApplicantDetails.FirstName,
                                           LastName = item.ApplicantDetails.LastName,
                                           PassportApplicationStatus = item.PassportApplicationStatus,
                                           PassportNumber = item.PassportNumber,
                                           ApplicationType = item.ServiceRequired.ApplicationType,
                                           PaymentStatus = item.PaymentStatus,
                                           PassportType = item.PassportType
                                       })
                                       .ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _contex.Users.FindAsync(id);
        }

        public async Task UpdateComplaint(int id, FeedbackDTO feedback)
        {
            try
            {
                Feedback userFeedback = await _contex.Feedbacks.FindAsync(id);
                if (userFeedback != null)
                {
                    userFeedback.FeedbackStatus = feedback.FeedbackStatus;
                    _contex.Feedbacks.Update(userFeedback);
                    await _contex.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public async Task UpdateNewPassport(int id, UpdatePassportDataDTO updatePassportDataDTO)
        {
            try
            {
                MasterDetailsTable passportData = await _contex.MasterDetailsTables.FindAsync(id);
                if (passportData != null)
                {
                    passportData.PassportApplicationStatus = updatePassportDataDTO.PassportApplicationStatus;
                    _contex.Update(passportData);
                    await _contex.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public async Task UpdateReNewPassport(int id, UpdatePassportDataDTO updatePassportDataDTO)
        {
            try
            {
                MasterDetailsTable passportData = await _contex.MasterDetailsTables.FindAsync(id);
                if (passportData != null)
                {
                    passportData.PassportApplicationStatus = updatePassportDataDTO.PassportApplicationStatus;
                    _contex.Update(passportData);
                    await _contex.SaveChangesAsync();
                }
            }catch(Exception ex)
            {

            }
        }

        public async Task UpdateUser(int id, UserDTO userDTO)
        {
            User userData = await _contex.Users.FindAsync(id);
            if (userData != null)
            {
                userData.FirstName = userDTO.FirstName;
                userData.LastName = userDTO.LastName;
                userData.PhoneNumber = userDTO.PhoneNumber;
                userData.EmailAddress = userDTO.EmailAddress;
                userData.LoginId = userDTO.LoginId;
                _contex.Users.Update(userData);
                await _contex.SaveChangesAsync();
            }
        }
    }
}
