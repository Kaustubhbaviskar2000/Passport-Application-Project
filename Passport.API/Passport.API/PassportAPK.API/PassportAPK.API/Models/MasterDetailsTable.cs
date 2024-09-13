using PassportAPK.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.Models
{
    public class MasterDetailsTable
    {
        [Key]
        public int MasterDetailsId { get; set; }

        //public int ApplicationNumber { get; set; }

        public int UserId { get; set; }     // FK
        public User User { get; set; }      // Reference Navigation Property.

        public string PassportApplicationStatus { get; set; }      

        public string PassportNumber { get; set; }

        public string PassportType { get; set; }               

        public string PaymentStatus { get; set; }             

        public int ServiceRequiredId { get; set; }                  // FK
        public ServiceRequired ServiceRequired { get; set; }      // Reference Navigation Property.                 

        public int ApplicantDetailsId { get; set; }                 // FK  

        public ApplicantDetails ApplicantDetails { get; set; }      // Reference Navigation Property.

        public int FamilyDetailId { get; set; }                     // FK

        public FamilyDetails FamilyDetails { get; set; }        // Reference Navigation Property.

        public int EmergencyContactDetailsId { get; set; }      // FK                

        public EmergencyContactDetails EmergencyContactDetails { get; set; }      // Reference Navigation Property.

        public int OtherDetailsId { get; set; }                         // FK        

        public OtherDetails OtherDetails { get; set; }                  // Reference Navigation Property.

        public int ResidentialDetailsId { get; set; }                   // FK               

        public ResidentailDetails ResidentailDetails { get; set; }      // Reference Navigation Property.

        public int SelfDeclarationId { get; set; }                      // FK

        public SelfDeclaration SelfDeclaration { get; set; }            // Reference Navigation Property.

        [DataType(DataType.DateTime)]
        public DateTime CreateOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }
    }
}
