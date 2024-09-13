using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class TrackPassportStatusDTO
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Select one option")]
        public string ApplicationType { get; set; }

        [Required(ErrorMessage ="Enter Passport Number")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="Passport number must be 10 digit")]
        public string PassportNumber { get; set; }
    }
}
