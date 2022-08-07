using System.ComponentModel.DataAnnotations;
using YoizenTestApp.Enums;

namespace YoizenTestApp.Models
{
    public class Client
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public ERole Role { get; set; }
        [Required]
        [MinLength(1)]
        public string Password { get; set; }

    }   
}
