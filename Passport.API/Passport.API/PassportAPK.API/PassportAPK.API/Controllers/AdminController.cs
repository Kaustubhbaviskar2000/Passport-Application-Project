using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;
using System.Collections.Generic;

namespace PassportAPK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private const string USER = "User"; 
        public AdminController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetAllFeedback")]
        public async Task<ActionResult<IEnumerable<FeedbackDTO>>> GetAllFeedback()
        {
            IEnumerable<Feedback> feedbaclList = await _unitOfWork.AdminRepository.GetAllFeedback();
            IEnumerable<FeedbackDTO> filteredFeedbackList = _mapper.Map<IEnumerable<FeedbackDTO>>(feedbaclList);
            return Ok(filteredFeedbackList);
        }

        [HttpGet]
        [Route("GetAllComplaints")]
        public async Task<ActionResult<IEnumerable<FeedbackDTO>>> GetAllComplaints()
        {
            IEnumerable<Feedback> feedbaclList = await _unitOfWork.AdminRepository.GetAllComplaints();
            IEnumerable<FeedbackDTO> filteredFeedbackList = _mapper.Map<IEnumerable<FeedbackDTO>>(feedbaclList);
            return Ok(filteredFeedbackList);
        }

        [HttpGet]
        [Route("GetComplaintById")]
        public async Task<ActionResult<FeedbackDTO>> GetComplaintById(int id)
        {
            Feedback filteredFeedback = await _unitOfWork.AdminRepository.GetComplentById(id);
            FeedbackDTO feedbackDTO = _mapper.Map<FeedbackDTO>(filteredFeedback);
            return feedbackDTO;
        }

        [HttpPut]
        [Route("UpdateComplaint")]
        public async Task<ActionResult> UpdateComplaint(int id,FeedbackDTO feedbackDTO)
        {
            try
            {
                await _unitOfWork.AdminRepository.UpdateComplaint(id, feedbackDTO);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteComplaint")]
        public async Task<ActionResult> DeleteComplaint(int id)
        {
            try
            {
                await _unitOfWork.AdminRepository.DeleteUserComplaint(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllUser")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUser()
        {
            IEnumerable<User> userList = await _unitOfWork.AdminRepository.GetAllUsers();
            IEnumerable<UserDTO> userDTOList = _mapper.Map<IEnumerable<UserDTO>>(userList);
            return Ok(userDTOList);
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                User user = await _unitOfWork.AdminRepository.GetUserById(id);
                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUser(int id,UserDTO userDTO)
        {
            try
            {
                await _unitOfWork.AdminRepository.UpdateUser(id, userDTO);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _unitOfWork.AdminRepository.DeleteUser(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetNewPassportDetail")]
        public async Task<ActionResult<IEnumerable<UpdatePassportDataDTO>>> GetNewPassportDetail()
        {
            try
            {
                return Ok(await _unitOfWork.AdminRepository.GetNewPassportData());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetNewPassportDetailById")]
        public async Task<ActionResult<IEnumerable<UpdatePassportDataDTO>>> GetNewPassportDetailById(int id)
        {
            try
            {
                return Ok(await _unitOfWork.AdminRepository.GetNewPassportDataById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpGet]
        [Route("GetReNewPassportDetail")]
        public async Task<ActionResult<IEnumerable<UpdatePassportDataDTO>>> GetReNewPassportDetail()
        {
            try
            {
                return Ok(await _unitOfWork.AdminRepository.GetReNewPassportData());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateNewPassportData")]
        public async Task<ActionResult> UpdateNewPassportData(int id,UpdatePassportDataDTO updatePassportDataDTO)
        {
            try
            {
                await _unitOfWork.AdminRepository.UpdateNewPassport(id,updatePassportDataDTO);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateReNewPassportData")]
        public async Task<ActionResult> UpdateReNewPassportData(int id, UpdatePassportDataDTO updatePassportDataDTO)
        {
            try
            {
                await _unitOfWork.AdminRepository.UpdateReNewPassport(id, updatePassportDataDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
