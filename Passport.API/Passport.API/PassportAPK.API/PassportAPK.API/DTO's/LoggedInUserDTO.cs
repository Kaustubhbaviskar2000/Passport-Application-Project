using System.ComponentModel.DataAnnotations;

namespace PassportAPK.API.DTO_s
{
    public class LoggedInUserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string LoginId { get; set; }
        public string UserRoles { get; set; }

        public string Token { get; set; }
    }
}
