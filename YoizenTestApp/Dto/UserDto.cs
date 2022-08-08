﻿using System.ComponentModel.DataAnnotations;

namespace YoizenTestApp.Dto
{
    public class UserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
