using System.ComponentModel.DataAnnotations;
using YoizenTestApp.Enums;
using YoizenTestApp.Models;

namespace YoizenTestApp.Dto
{
    public record ClientDto
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

        public static explicit operator ClientDto(Client client) 
        {
            ClientDto retorno = new ClientDto()
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Role = client.Role,
                Password = client.Password
            }; 
            return retorno;
        }
    }
}
