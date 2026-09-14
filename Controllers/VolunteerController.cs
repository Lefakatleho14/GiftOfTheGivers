using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;
using GiftOfTheGivers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGivers.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolunteerController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new VolunteerViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(
            VolunteerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var application = new VolunteerApplication
            {
                Name = model.Name,
                Email = model.Email,
                Skills = model.Skills,
                Availability = model.Availability
            };

            _context.VolunteerApplications.Add(application);

            await _context.SaveChangesAsync();

            return RedirectToAction(
                nameof(Success));
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}