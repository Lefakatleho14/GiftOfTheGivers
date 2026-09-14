using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class VolunteerApplication
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Skills { get; set; } = string.Empty;

        [Required]
        public string Availability { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}