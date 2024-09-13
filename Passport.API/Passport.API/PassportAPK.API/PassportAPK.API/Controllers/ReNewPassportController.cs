using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Repository;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReNewPassportController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReNewPassportController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateReNewPassport")]
        public async Task<ActionResult> CreateReNewPassport(NewPassportApplyDTO newPassportApplyDTO)
        {
            NewPassport newPassport = new NewPassport(_unitOfWork,_mapper);
            newPassport.InItMasterData(newPassportApplyDTO);
            await newPassport.AddServiceRequired(newPassportApplyDTO.ServiceRequired);
            await newPassport.AddApplicantDetails(newPassportApplyDTO.ApplicantDetails);
            await newPassport.AddResidentailDetails(newPassportApplyDTO.ResidentailDetails);
            await newPassport.AddFamilyDetails(newPassportApplyDTO.FamilyDetails);
            await newPassport.AddEmergencyContactDetails(newPassportApplyDTO.EmergencyContactDetails);
            await newPassport.AddOtherDetails(newPassportApplyDTO.OtherDetails);
            await newPassport.AddSelfDeclaration(newPassportApplyDTO.SelfDeclaration);
            return NoContent();
        }
    }
}
