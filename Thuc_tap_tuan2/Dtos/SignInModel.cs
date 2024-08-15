﻿using System.ComponentModel.DataAnnotations;

namespace Thuc_tap_tuan2.Dtos
{
    public class SignInModel
    {
        [Required, EmailAddress]

        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!; 
    }
}
