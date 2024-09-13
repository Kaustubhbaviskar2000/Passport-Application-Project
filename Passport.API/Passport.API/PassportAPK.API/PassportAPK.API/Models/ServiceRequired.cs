using PassportAPK.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.Models
{
    public class ServiceRequired
    {
        [Key]
        public int ServiceRequiredId { get; set; }

        [Required (ErrorMessage = "Please Select one option")]
        public string ApplicationType { get; set; }

        [Required(ErrorMessage = "Please Select one option")]
        public string PagesRequired { get; set; }

        [Required(ErrorMessage = "Please Select one option")]
        public string ValidityRequired { get; set; }

        public string ReasonForReNewal { get; set; }

        public string ChangeInAppreance { get; set; }
    }
}
