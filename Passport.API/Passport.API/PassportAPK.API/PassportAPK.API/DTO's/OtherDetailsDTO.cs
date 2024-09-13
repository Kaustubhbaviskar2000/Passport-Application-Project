using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class OtherDetailsDTO
    {
        public int? OtherDetailsId { get; set; }

        [Required(ErrorMessage = "Please specify if there are any criminal proceedings.")]
        public string IsCriminalProceedings { get; set; }

        [Required(ErrorMessage = "Please specify if there is any warrant or summons.")]
        public string IsWarrantSummons { get; set; }

        [Required(ErrorMessage = "Please specify if there is any arrest warrant.")]
        public string IsArrestWarrant { get; set; }

        [Required(ErrorMessage = "Please specify if there is any departure order.")]
        public string IsDepartureOrder { get; set; }

        [Required(ErrorMessage = "Please specify if there has been any conviction.")]
        public string IsConviction { get; set; }

        [Required(ErrorMessage = "Please specify if there has been a passport refusal.")]
        public string IsPassportRefusal { get; set; }

        [Required(ErrorMessage = "Please specify if the passport has been impounded.")]
        public string IsPassportImpounded { get; set; }

        [Required(ErrorMessage = "Please specify if the passport has been revoked.")]
        public string IsPassportRevoked { get; set; }

        [Required(ErrorMessage = "Please specify if you have foreign citizenship.")]
        public string IsForeignCitizenship { get; set; }

        [Required(ErrorMessage = "Please specify if you possess another passport.")]
        public string IsOtherPassport { get; set; }

        [Required(ErrorMessage = "Please specify if you have surrendered a passport.")]
        public string IsSurrenderedPassport { get; set; }

        [Required(ErrorMessage = "Please specify if you have renounced citizenship.")]
        public string IsRenunciation { get; set; }

        [Required(ErrorMessage = "Please specify if you possess an emergency certificate.")]
        public string IsEmergencyCertificate { get; set; }

        [Required(ErrorMessage = "Please specify if you have been deported.")]
        public string IsDeported { get; set; }

        [Required(ErrorMessage = "Please specify if you have been repatriated.")]
        public string IsRepatriated { get; set; }
    }
}
