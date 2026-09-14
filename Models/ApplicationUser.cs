using Microsoft.AspNetCore.Identity;

namespace GiftOfTheGivers.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}