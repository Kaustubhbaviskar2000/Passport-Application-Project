using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassportAPK.API.Models
{
    public class SelfDeclaration
    {
        [Key]
        public int SelfDeclarationId { get; set; }

        [Required(ErrorMessage = "Please Accept the terms and conditions.")]
        public bool IsAcceptTermsAndCondition { get; set; }

        [Required(ErrorMessage = "Please enter the palce")]
        public string Place { get; set; }

        [Required(ErrorMessage = "Please enter the Date")]
        [DataType(DataType.Date)]
        public DateTime? DateOfApplied { get; set; }

        /*public byte[]? ApplicantPhoto { get; set; }

        

        public byte[]? Signature { get; set; }
        


        public byte[]? AdharCard { get; set; }
        

        public byte[]? PanCard { get; set; }*/
        
    }
}
