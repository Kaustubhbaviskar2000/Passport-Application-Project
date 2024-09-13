using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeedbackController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateNewFeedback")]
        public async Task<ActionResult> CreateNewFeedback(FeedbackDTO feedbackDTO)
        {
            if (!ModelState.IsValid)
                BadRequest();

            if(feedbackDTO != null)
            {
                var newFeedback = _mapper.Map<Feedback>(feedbackDTO);
                await _unitOfWork.FeedbackRepository.CreateAsync(newFeedback);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
