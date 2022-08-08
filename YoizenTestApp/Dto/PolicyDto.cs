using System.ComponentModel.DataAnnotations;
using YoizenTestApp.Models;

namespace YoizenTestApp.Dto
{
    public record PolicyDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public double AmountInsured { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime InceptionDate { get; set; }
        [Required]
        public bool InstallmentPayment { get; set; }
        [Required]
        public Guid ClientId { get; set; }

        public static explicit operator PolicyDto(Policy policy)
        {
            PolicyDto retorno = new PolicyDto()
            {
                Id = policy.Id,
                AmountInsured = policy.AmountInsured,
                Email = policy.Email,
                InceptionDate = policy.InceptionDate,
                InstallmentPayment = policy.InstallmentPayment,
                ClientId = policy.ClientId
            };
            return retorno;
        }
    }
}
