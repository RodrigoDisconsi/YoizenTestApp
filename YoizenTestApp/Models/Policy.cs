using System.ComponentModel.DataAnnotations;

namespace YoizenTestApp.Models
{
    public class Policy
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
    }
}
