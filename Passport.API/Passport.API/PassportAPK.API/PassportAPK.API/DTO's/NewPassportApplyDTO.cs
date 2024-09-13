using PassportAPK.API.Enums;
using PassportAPK.API.Models;

namespace PassportAPK.API.DTO_s
{
    public class NewPassportApplyDTO
    {
        
        public ServiceRequiredDTO ServiceRequired { get; set; }
        public ApplicantDetailsDTO ApplicantDetails { get; set; }
        public FamilyDetailsDTO FamilyDetails { get; set; }
        public OtherDetailsDTO OtherDetails { get; set; }
        public EmergencyContactDetailsDTO EmergencyContactDetails { get; set; }
        public SelfDeclarationDTO SelfDeclaration { get; set; }
        public ResidentailDetailsDTO ResidentailDetails { get; set; }
        //public MasterDetailsTable MasterDetailsTable { get; set; }
        //public IFormFile ApplicantPhoto { get; set; }
        //public IFormFile Signature { get; set; }
        //public IFormFile AdharCard { get; set; }
        //public IFormFile PanCard { get; set; }

        public string PaymentStatus { get; set; }

        public string PassportType { get; set; }
        public string PassportNumber { get; set; }

        public string PassportApplicationStatus { get; set; }
        //public string ApplicationNumber { get; set; }
        public int UserId { get; set; }
    }
}
