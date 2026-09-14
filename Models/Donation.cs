using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; } = "ZAR";

        [Required]
        public string DonationType { get; set; } = "One Time";

        public string? Purpose { get; set; }

        public string? DonorName { get; set; }

        public string? DonorEmail { get; set; }

        public string? UserId { get; set; }

        public bool IsAnonymous { get; set; }

        public string Status { get; set; } = "Completed";

        public string Reference { get; set; } =
            $"GOTG-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}