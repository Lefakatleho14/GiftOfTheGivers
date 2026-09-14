using GiftOfTheGivers.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftOfTheGivers.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var donations =
                await _context.Donations.CountAsync();

            var volunteers =
                await _context.VolunteerApplications.CountAsync();

            var reliefUpdates =
                await _context.ReliefUpdates.CountAsync();

            var totalDonations =
                await _context.Donations
                    .SumAsync(d => (decimal?)d.Amount) ?? 0;

            ViewBag.DonationCount = donations;
            ViewBag.VolunteerCount = volunteers;
            ViewBag.ReliefUpdateCount = reliefUpdates;
            ViewBag.TotalDonations = totalDonations;

            ViewBag.RecentVolunteers =
                await _context.VolunteerApplications
                    .OrderByDescending(v => v.SubmittedAt)
                    .Take(5)
                    .ToListAsync();

            return View();
        }

        public async Task<IActionResult> Volunteers()
        {
            var volunteers =
                await _context.VolunteerApplications
                    .OrderByDescending(v => v.SubmittedAt)
                    .ToListAsync();

            return View(volunteers);
        }
    }
}
