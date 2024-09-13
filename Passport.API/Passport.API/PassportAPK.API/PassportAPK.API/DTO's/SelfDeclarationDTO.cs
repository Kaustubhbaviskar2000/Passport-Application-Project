using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class SelfDeclarationDTO
    {
        public int? SelfDeclarationId { get; set; }

        [Required(ErrorMessage = "Please Accept the terms and conditions.")]
        public bool IsAcceptTermsAndCondition { get; set; }

        [Required(ErrorMessage = "Please enter the palce")]
        public string Place { get; set; }

        [Required(ErrorMessage = "Please enter the Date")]
        [DataType(DataType.Date)]
        public DateTime? DateOfApplied { get; set; }

    }
}
