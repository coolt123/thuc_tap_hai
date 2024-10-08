﻿using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!; 
        public string LastName { get; set; } = null!;
    }
}
