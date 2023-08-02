﻿using System.ComponentModel.DataAnnotations;

namespace LoginAndRegister.Models.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}