using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.ViewModels
{
    public class ReliefUpdateViewModel
    {
        [Required]
        [Display(Name = "Relief project")]
        public int ReliefProjectId { get; set; }

        [Required]
        [StringLength(2000)]
        [Display(Name = "Update")]
        public string Content { get; set; } = string.Empty;
    }
}