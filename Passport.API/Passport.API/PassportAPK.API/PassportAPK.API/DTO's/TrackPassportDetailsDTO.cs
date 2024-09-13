using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class TrackPassportDetailsDTO
    {
        [Required(ErrorMessage = "First or Middle name must be required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Enter Minimun 4 and maximum 50 character")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surnmae name must be required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Enter Minimun 4 and maximum 50 character")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Select one option")]
        public string ApplicationType { get; set; }

        [Required(ErrorMessage = "Enter Passport Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Passport number must be 10 digit")]
        public string PassportNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string PassportApplicationStatus { get; set; }

        public string PaymentStatus { get; set; }
    }
}
