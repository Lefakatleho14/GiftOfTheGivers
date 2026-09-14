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

        public DbSet<Donation> Donations { get; set; }

        public DbSet<VolunteerApplication> VolunteerApplications
        {
            get;
            set;
        }

        public DbSet<ReliefProject> ReliefProjects
        {
            get;
            set;
        }

        public DbSet<ReliefUpdate> ReliefUpdates
        {
            get;
            set;
        }
    }
}