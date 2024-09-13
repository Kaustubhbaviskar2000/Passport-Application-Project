using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class FeedbackDTO
    {
        public int? FeedbackId { get; set; }
        
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Email address must be between 4 and 25 characters.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "User name must be between 6 and 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Feedback description is required.")]
        [StringLength(1000, ErrorMessage = "Feedback description can be up to 1000 characters.")]
        public string FeedbackDescription { get; set; }

        public string FeedbackStatus { get; set; }

        [Required(ErrorMessage = "Feedback type is required.")]
        public string FeedbackType { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Enter a valid date and time.")]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Enter a valid date and time.")]
        public DateTime UpdatedOn { get; set; }

        public int UserId { get; set; }

    }
}

