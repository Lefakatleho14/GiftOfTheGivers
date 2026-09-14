using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;
using GiftOfTheGivers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftOfTheGivers.Controllers
{
    [Authorize(Roles = "Employee")]
    public class ReliefController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReliefController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Projects()
        {
            var projects = await _context.ReliefProjects
                .Include(p => p.Updates)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return View(projects);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            return View(new ReliefProjectViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(
            ReliefProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var project = new ReliefProject
            {
                Name = model.Name,
                Location = model.Location,
                Description = model.Description,
                Status = model.Status
            };

            _context.ReliefProjects.Add(project);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Projects));
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdate()
        {
            ViewBag.Projects = await _context.ReliefProjects
                .Where(p => p.Status != "Completed")
                .OrderBy(p => p.Name)
                .ToListAsync();

            return View(new ReliefUpdateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUpdate(
            ReliefUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Projects = await _context.ReliefProjects
                    .Where(p => p.Status != "Completed")
                    .OrderBy(p => p.Name)
                    .ToListAsync();

                return View(model);
            }

            var employee =
                await _userManager.GetUserAsync(User);

            if (employee == null)
            {
                return Challenge();
            }

            var project = await _context.ReliefProjects
                .FindAsync(model.ReliefProjectId);

            if (project == null)
            {
                ModelState.AddModelError(
                    "ReliefProjectId",
                    "The selected relief project could not be found.");

                ViewBag.Projects = await _context.ReliefProjects
                    .Where(p => p.Status != "Completed")
                    .OrderBy(p => p.Name)
                    .ToListAsync();

                return View(model);
            }

            var update = new ReliefUpdate
            {
                EmployeeId = employee.Id,
                ReliefProjectId = model.ReliefProjectId,
                Content = model.Content
            };

            _context.ReliefUpdates.Add(update);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Projects));
        }
    }
}
