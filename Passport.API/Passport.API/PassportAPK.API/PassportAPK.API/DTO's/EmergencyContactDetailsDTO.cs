using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class EmergencyContactDetailsDTO
    {
        public int? EmergencyContactDetailsId { get; set; }

        [Required(ErrorMessage = "Enter Contact name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Contact name length sould be between 3 to 50.")]
        public string ContactName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Contact name length sould be between 3 to 100.")]
        public string Address { get; set; }

        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter email address")]
        [EmailAddress(ErrorMessage = "Enter Valid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Enter City")]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
    }
}
