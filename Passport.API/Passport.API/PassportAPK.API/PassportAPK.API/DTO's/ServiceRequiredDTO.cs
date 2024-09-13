using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class ServiceRequiredDTO
    {
        public int? ServiceRequiredId { get; set; }

        [Required(ErrorMessage = "Please Select one option")]
        public string ApplicationType { get; set; }

        [Required(ErrorMessage = "Please Select one option")]
        public string PagesRequired { get; set; }

        [Required(ErrorMessage = "Please Select one option")]
        public string ValidityRequired { get; set; }

        public string ReasonForReNewal { get; set; }

        public string ChangeInAppreance { get; set; }
    }
}
