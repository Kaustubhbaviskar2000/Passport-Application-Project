﻿using Microsoft.AspNetCore.Identity;

namespace PassportAPK.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string LoginId { get; set; }
    }
}
