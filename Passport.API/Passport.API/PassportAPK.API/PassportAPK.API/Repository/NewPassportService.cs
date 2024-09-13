using AutoMapper;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class NewPassportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private MasterDetailsTable _masterDetails;
        private readonly IMapper _mapper;
        public NewPassportService()
        {
            
        }
        public NewPassportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _masterDetails = new MasterDetailsTable();
            _mapper = mapper;
        }
        public void InItMasterData(ReNewPassportApplyDTO newPassportApplyDTO)
        {
            _masterDetails.PassportApplicationStatus = newPassportApplyDTO.PassportApplicationStatus.ToString();
            _masterDetails.PassportNumber = newPassportApplyDTO.PassportNumber;
            _masterDetails.PaymentStatus = newPassportApplyDTO.PaymentStatus;
            _masterDetails.UserId = newPassportApplyDTO.UserId;
        }
        public async Task AddServiceRequiredAsync(ServiceRequiredDTO serviceRequired)
        {
            ServiceRequired serviceData = _mapper.Map<ServiceRequired>(serviceRequired);
            await _unitOfWork.ServiceRequiredRepository.AddServiceRequiredAsync(serviceData);
            _masterDetails.ServiceRequiredId = serviceData.ServiceRequiredId;
        }
        public async Task AddApplicantDetailsAsync(ApplicantDetailsDTO applicantDetails)
        {
            ApplicantDetails applicantData =  _mapper.Map<ApplicantDetails>(applicantDetails);
            await _unitOfWork.ApplicantDetailsRepository.AddApplicantDetailsAsync(applicantData);
            _masterDetails.ApplicantDetailsId = applicantData.ApplicantDetailsId;
        }
        public async Task AddResidentailDetailsAsync(ResidentailDetailsDTO residentailDetails)
        {
            ResidentailDetails residentailData = _mapper.Map<ResidentailDetails>(residentailDetails);
            await _unitOfWork.ResidentailDetailsRepository.AddResidentialDetailAsync(residentailData);
            _masterDetails.ResidentialDetailsId = residentailData.ResidentialDetailsId;
        }
        public async Task AddFamilyDetailsASync(FamilyDetailsDTO familyDetails)
        {
            FamilyDetails familyData = _mapper.Map<FamilyDetails>(familyDetails);
            await _unitOfWork.FamilyDetailsRepository.AddFamilyDetailsAsync(familyData);
            _masterDetails.FamilyDetailId = familyData.FamilyDetailId;
        }
        public async Task AddEmergencyContactDetailsAsync(EmergencyContactDetailsDTO emergencyContactDetails)
        {
            EmergencyContactDetails emergencyContactData = _mapper.Map<EmergencyContactDetails>(emergencyContactDetails);
            await _unitOfWork.EmergencyContactDetailsRepository.AddEmergencyContactDetailsAsync(emergencyContactData);
            _masterDetails.EmergencyContactDetailsId = emergencyContactData.EmergencyContactDetailsId;
        }
        public async Task AddOtherDetailsAsync(OtherDetailsDTO otherDetails)
        {
            OtherDetails otherData = _mapper.Map<OtherDetails>(otherDetails);
            await _unitOfWork.OtherDetailsRepository.AddOtherDetailsAsync(otherData);
            _masterDetails.OtherDetailsId = otherData.OtherDetailsId;
        }

        public async Task AddSelfDeclarationAsync(SelfDeclarationDTO selfDeclaration)
        {
            SelfDeclaration selfDeclarationData = _mapper.Map<SelfDeclaration>(selfDeclaration);
            await _unitOfWork.SelfDeclarationRepository.AddSelfDeclarationAsync(selfDeclarationData);
            _masterDetails.SelfDeclarationId = selfDeclarationData.SelfDeclarationId;
            await _unitOfWork.MasterDetailsTableRepository.AddMasterDetailsAsync(_masterDetails);
        }
    }
}
