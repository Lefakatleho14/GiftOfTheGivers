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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Volunteers()
        {
            var applications = await _context.VolunteerApplications
                .AsNoTracking()
                .OrderByDescending(v => v.SubmittedAt)
                .ToListAsync();

            return View(applications);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVolunteerStatus(
            int id,
            string status)
        {
            var allowedStatuses = new[]
            {
                "Pending",
                "Reviewed",
                "Contacted",
                "Accepted",
                "Declined"
            };

            if (!allowedStatuses.Contains(status))
            {
                return BadRequest();
            }

            var application =
                await _context.VolunteerApplications.FindAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            application.Status = status;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Volunteers));
        }
    }
}