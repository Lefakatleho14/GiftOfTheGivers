using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class ReliefUpdate
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string? Location { get; set; }

        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

        public string? EmployeeId { get; set; }
    }
}