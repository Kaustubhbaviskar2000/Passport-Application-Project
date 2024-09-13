using PassportAPK.API.Models;
using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class MasterDetailsTableDTO
    {
        public int? MasterDetailsId { get; set; }

        public int UserId { get; set; }     // FK

        public string PassportApplicationStatus { get; set; }

        public string PassportNumber { get; set; }
        public string PassportType { get; set; }

        public string PaymentStatus { get; set; }

        public int ServiceRequiredId { get; set; }                  // FK

        public int ApplicantDetailsId { get; set; }                 // FK  

        public int FamilyDetailId { get; set; }                     // FK

        public int EmergencyContactDetailsId { get; set; }      // FK                

        public int OtherDetailsId { get; set; }                         // FK        

        public int ResidentialDetailsId { get; set; }                   // FK               

        public int SelfDeclarationId { get; set; }                      // FK

        [DataType(DataType.DateTime)]
        public DateTime CreateOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }
    }
}
