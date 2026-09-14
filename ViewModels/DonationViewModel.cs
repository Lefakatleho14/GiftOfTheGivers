using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.ViewModels
{
    public class DonationViewModel
    {
        [Required]
        [Range(1, 100000000)]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; } = "ZAR";

        [Required]
        public string DonationType { get; set; } = "One Time";

        public string? Purpose { get; set; }

        public bool IsAnonymous { get; set; }

        public string? DonorName { get; set; }

        [EmailAddress]
        public string? DonorEmail { get; set; }
    }
}