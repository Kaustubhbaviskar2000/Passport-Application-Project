using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.Models
{
    public class FamilyDetails
    {
        [Key]
        public int FamilyDetailId { get; set; }

        [Required(ErrorMessage = "Father's first name is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Father's first name must be between 6 and 50 characters.")]
        public string FatherFirstName { get; set; }

        [Required(ErrorMessage = "Father's last name is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Father's last name must be between 6 and 50 characters.")]
        public string FatherLastName { get; set; }

        [Required(ErrorMessage = "Mother's first name is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mother's first name must be between 6 and 50 characters.")]
        public string MotherFirstName { get; set; }

        [Required(ErrorMessage = "Mother's last name is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mother's last name must be between 6 and 50 characters.")]
        public string MotherLastName { get; set; }

        [StringLength(50, MinimumLength = 6, ErrorMessage = "Legal guardian's first name must be between 6 and 50 characters.")]
        public string LegalGuardianFirstName { get; set; }

        [StringLength(50, MinimumLength = 6, ErrorMessage = "Legal guardian's last name must be between 6 and 50 characters.")]
        public string LegalGuardianLastName { get; set; }


        [StringLength(50, MinimumLength = 6, ErrorMessage = "Spouse's first name must be between 6 and 50 characters.")]
        public string SpouceFirstName { get; set; }

        [StringLength(50, MinimumLength = 6, ErrorMessage = "Spouse's last name must be between 6 and 50 characters.")]
        public string SpouceLastName { get; set; }

        
    }
}
