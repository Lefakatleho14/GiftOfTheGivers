using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GiftOfTheGivers.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Donations
        public DbSet<Donation> Donations { get; set; }

        // Volunteer applications
        public DbSet<VolunteerApplication> VolunteerApplications
        {
            get;
            set;
        }

        // Relief project updates
        public DbSet<ReliefUpdate> ReliefUpdates
        {
            get;
            set;
        }
    }
}