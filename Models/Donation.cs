using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class Donation
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        [Required]
        [Range(1, 100000000)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; } = "ZAR";

        [Required]
        [StringLength(30)]
        public string DonationType { get; set; } = "One Time";

        [StringLength(30)]
        public string? DonationFrequency { get; set; }

        [Required]
        [StringLength(100)]
        public string Purpose { get; set; } = "General Relief";

        public bool IsAnonymous { get; set; }

        [StringLength(150)]
        public string? DonorName { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string? DonorEmail { get; set; }

        [Required]
        [StringLength(30)]
        public string DonationStatus { get; set; } = "Recorded";

        [Required]
        [StringLength(30)]
        public string Reference { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}