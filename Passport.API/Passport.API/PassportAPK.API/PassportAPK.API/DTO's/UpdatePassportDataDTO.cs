using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class UpdatePassportDataDTO
    {
        public int? MasterDetailsId { get; set; }

        [Required(ErrorMessage = "First or Middle name must be required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Enter Minimun 4 and maximum 50 character")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surnmae name must be required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Enter Minimun 4 and maximum 50 character")]
        public string LastName { get; set; }

        public string PassportApplicationStatus { get; set; }

        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Please Select one option")]
        public string ApplicationType { get; set; }

        public string PaymentStatus { get; set; }
        public string PassportType { get; set; }
    }
}
