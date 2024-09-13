using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class ResidentailDetailsDTO
    {
        public int? ResidentialDetailsId { get; set; }

        [Required(ErrorMessage = "House number and name are required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "House number and name must be between 2 and 50 characters.")]
        public string HouseNoAndName { get; set; }

        [Required(ErrorMessage = "Address Lane 1 is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Address Lane 1 must be between 2 and 50 characters.")]
        public string AddressLane1 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City must be between 2 and 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Mobile number must be between 10 and 15 characters.")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Mobile number must contain only digits.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "District is required.")]
        public string District { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Pin code is required.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Pin code must be exactly 6 digits.")]
        public string PinCode { get; set; }
    }
}
