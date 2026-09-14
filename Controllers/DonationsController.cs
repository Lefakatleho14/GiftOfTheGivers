using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;
using GiftOfTheGivers.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGivers.Controllers
{
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DonationsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new DonationViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            DonationViewModel model)
        {
            if (model.DonationType == "Recurring" &&
                string.IsNullOrWhiteSpace(model.DonationFrequency))
            {
                ModelState.AddModelError(
                    nameof(model.DonationFrequency),
                    "Please select a recurring donation frequency.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var donation = new Donation
            {
                Amount = model.Amount,
                Currency = model.Currency,
                DonationType = model.DonationType,
                DonationFrequency =
                    model.DonationType == "Recurring"
                        ? model.DonationFrequency
                        : null,
                Purpose = model.Purpose,
                IsAnonymous = model.IsAnonymous,
                DonorName = model.IsAnonymous
                    ? "Anonymous"
                    : model.DonorName,
                DonorEmail = model.DonorEmail,
                DonationStatus = "Recorded",
                Reference = GenerateReference(),
                CreatedAt = DateTime.UtcNow
            };

            if (User.Identity?.IsAuthenticated == true)
            {
                var user = await _userManager.GetUserAsync(User);

                donation.UserId = user?.Id;

                if (!model.IsAnonymous)
                {
                    donation.DonorName =
                        user?.FullName ?? model.DonorName;

                    donation.DonorEmail =
                        user?.Email ?? model.DonorEmail;
                }
            }

            _context.Donations.Add(donation);

            await _context.SaveChangesAsync();

            return RedirectToAction(
                nameof(Confirmation),
                new { id = donation.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Confirmation(int id)
        {
            var donation =
                await _context.Donations.FindAsync(id);

            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        private static string GenerateReference()
        {
            return $"GOTG-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid()
                .ToString("N")[..6]
                .ToUpper()}";
        }
    }
}