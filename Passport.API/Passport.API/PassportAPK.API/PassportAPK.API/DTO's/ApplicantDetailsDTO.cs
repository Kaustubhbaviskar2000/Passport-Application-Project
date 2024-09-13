using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class ApplicantDetailsDTO
    {
        public int? ApplicantDetailsId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Enter minimum 6 and maximum 100 length ")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Enter minimum 6 and maximum 100 length ")]
        public string LastName { get; set; }

        public string IsAliasName { get; set; }

        [StringLength(100)]
        public string AliasName { get; set; }

        public string IsChangedName { get; set; }

        public string ChangedName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length should be between 3 to 50.")]
        public string PlaceOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter the valid pan card number")]
        public string PanCardNumber { get; set; }



        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter the valid Voter Id Number number")]
        public string VoterId { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Please enter the valid Adhar card number")]
        public string AdharCardNumber { get; set; }

        [Required]
        public string MaritialStatus { get; set; }

        [Required]
        public string EmployeementType { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length should be between 3 to 50.")]
        public string OrganizationalName { get; set; }

        public string EducationQualification { get; set; }

        public int Citizenship { get; set; }            // Enum

        [Required]
        public string IsNonECR { get; set; }
        [Required]
        public string DistinguishMark { get; set; }

        [Required]
        public string parentOrSpouseGovServant { get; set; }

        public string PassportNumber { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string PlaceOfIssue { get; set; }
    }
}
