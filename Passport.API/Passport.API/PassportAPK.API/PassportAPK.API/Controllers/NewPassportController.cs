using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;
using PassportAPK.API.Repository;
using PassportAPK.API.Repository.IRepository;
using System.Security.Cryptography.Xml;

namespace PassportAPK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewPassportController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewPassportController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("NewPassportApply")]
        public async Task<ActionResult> NewPassportApply(NewPassportApplyDTO newPassportApplyDTO)
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

    public class NewPassport
    {
        private readonly IUnitOfWork _unitOfWork;
        private MasterDetailsTable _masterDetails;
        private readonly IMapper _mapper;
        public NewPassport(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _masterDetails = new MasterDetailsTable();
            _mapper = mapper;
        }
        public void InItMasterData(NewPassportApplyDTO newPassportApplyDTO)
        {
            _masterDetails.PassportType = newPassportApplyDTO.PassportType;
            _masterDetails.PassportApplicationStatus = newPassportApplyDTO.PassportApplicationStatus.ToString();
            _masterDetails.PassportNumber = newPassportApplyDTO.PassportNumber;
            _masterDetails.PaymentStatus = newPassportApplyDTO.PaymentStatus;
            _masterDetails.UserId = newPassportApplyDTO.UserId;
        }
        public async Task AddServiceRequired(ServiceRequiredDTO serviceRequired)
        {
            ServiceRequired serviceData = _mapper.Map<ServiceRequired>(serviceRequired);
            await _unitOfWork.ServiceRequiredRepository.AddServiceRequiredAsync(serviceData);
            _masterDetails.ServiceRequiredId = serviceData.ServiceRequiredId;
        }
        public async Task AddApplicantDetails(ApplicantDetailsDTO applicantDetails)
        {
            ApplicantDetails applicantData = _mapper.Map<ApplicantDetails>(applicantDetails);
            await _unitOfWork.ApplicantDetailsRepository.AddApplicantDetailsAsync(applicantData);
            _masterDetails.ApplicantDetailsId = applicantData.ApplicantDetailsId;
        }
        public async Task AddResidentailDetails(ResidentailDetailsDTO residentailDetails)
        {
            ResidentailDetails residentailData = _mapper.Map<ResidentailDetails>(residentailDetails);
            await _unitOfWork.ResidentailDetailsRepository.AddResidentialDetailAsync(residentailData);
            _masterDetails.ResidentialDetailsId = residentailData.ResidentialDetailsId;
        }
        public async Task AddFamilyDetails(FamilyDetailsDTO familyDetails)
        {
            FamilyDetails familyData = _mapper.Map<FamilyDetails>(familyDetails);
            await _unitOfWork.FamilyDetailsRepository.AddFamilyDetailsAsync(familyData);
            _masterDetails.FamilyDetailId = familyData.FamilyDetailId;
        }
        public async Task AddEmergencyContactDetails(EmergencyContactDetailsDTO emergencyContactDetails)
        {
            EmergencyContactDetails emergencyContactData = _mapper.Map<EmergencyContactDetails>(emergencyContactDetails);
            await _unitOfWork.EmergencyContactDetailsRepository.AddEmergencyContactDetailsAsync(emergencyContactData);
            _masterDetails.EmergencyContactDetailsId = emergencyContactData.EmergencyContactDetailsId;
        }
        public async Task AddOtherDetails(OtherDetailsDTO otherDetails)
        {
            OtherDetails otherData = _mapper.Map<OtherDetails>(otherDetails);
            await _unitOfWork.OtherDetailsRepository.AddOtherDetailsAsync(otherData);
            _masterDetails.OtherDetailsId = otherData.OtherDetailsId;
        }
        
        public async Task AddSelfDeclaration(SelfDeclarationDTO selfDeclaration)
        {
            /*if(applicantPhoto != null)
            {
                selfDeclaration.ApplicantPhoto = await ConvertToByteArrayAsync(applicantPhoto);
            }
            if (signature != null)
            {
                selfDeclaration.Signature = await ConvertToByteArrayAsync(signature);
            }
            if (adharCard != null)
            {
                selfDeclaration.AdharCard = await ConvertToByteArrayAsync(adharCard);
            }
            
            

            if (panCard != null)
            {
                selfDeclaration.PanCard = await ConvertToByteArrayAsync(panCard);
            }*/
            SelfDeclaration selfDeclarationData = _mapper.Map<SelfDeclaration>(selfDeclaration);
            await _unitOfWork.SelfDeclarationRepository.AddSelfDeclarationAsync(selfDeclarationData);
            _masterDetails.SelfDeclarationId = selfDeclarationData.SelfDeclarationId;
            await _unitOfWork.MasterDetailsTableRepository.AddMasterDetailsAsync(_masterDetails);
        }

        private async Task<byte[]> ConvertToByteArrayAsync(IFormFile formFile)
        {
            if (formFile == null)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }
}
