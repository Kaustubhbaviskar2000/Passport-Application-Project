namespace PassportAPK.API.DTO_s
{
    public class ReNewPassportApplyDTO
    {
        public ServiceRequiredDTO ServiceRequiredDTO { get; set; }

        public ApplicantDetailsDTO ApplicantDetailsDTO { get; set; }

        public ResidentailDetailsDTO ResidentailDetailsDTO { get; set; }

        public FamilyDetailsDTO FamilyDetailsDTO { get; set; }

        public EmergencyContactDetailsDTO EmergencyContactDetailsDTO { get; set; }
        public OtherDetailsDTO OtherDetailsDTO { get; set; }
        public SelfDeclarationDTO SelfDeclarationDTO { get; set; }

        public string PaymentStatus { get; set; }
        public string PassportNumber { get; set; }

        public string PassportApplicationStatus { get; set; }
        public int UserId { get; set; }
    }
}
