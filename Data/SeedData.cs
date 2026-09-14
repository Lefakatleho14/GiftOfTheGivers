using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Identity;

namespace GiftOfTheGivers.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(
            IServiceProvider serviceProvider)
        {
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles =
            {
                "Donor",
                "Employee"
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole(role));
                }
            }

            // Development employee account
            var employeeEmail = "employee@giftofthegivers.local";

            var employee =
                await userManager.FindByEmailAsync(employeeEmail);

            if (employee == null)
            {
                employee = new ApplicationUser
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    EmailConfirmed = true,
                    FullName = "Gift of the Givers Employee"
                };

                var result = await userManager.CreateAsync(
                    employee,
                    "Employee123");

                if (!result.Succeeded)
                {
                    throw new Exception(
                        "Failed to create the development employee account.");
                }
            }

            if (!await userManager.IsInRoleAsync(
                    employee,
                    "Employee"))
            {
                await userManager.AddToRoleAsync(
                    employee,
                    "Employee");
            }
        }
    }
}