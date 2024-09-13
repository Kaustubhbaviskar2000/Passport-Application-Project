using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("TrackPassportStatus")]
        public async Task<ActionResult<TrackPassportDetailsDTO>> TrackPassportStatus(TrackPassportStatusDTO trackPassportStatusDTO)
        {
            if (!ModelState.IsValid)
                BadRequest();

            TrackPassportDetailsDTO trackDetails =  await _unitOfWork.MasterDetailsTableRepository.GetPassportDetailByPassportNumber(trackPassportStatusDTO);
            if(trackDetails != null)
            {
                return Ok(trackDetails);
            }
            else
            {
                return BadRequest(new { message = "Application Number not found." });
            } 
        }


        [HttpPost]
        [Route("MakePayment")]
        public async Task<ActionResult> MakePayment(PaymentDTO paymentDTO)
        {
            try
            {
                await _unitOfWork.MasterDetailsTableRepository.ConfirmPassportPayment(paymentDTO);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }            
        }
    }
}
