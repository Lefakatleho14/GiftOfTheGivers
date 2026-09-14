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
                "Employee",
                "Donor"
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole(role));
                }
            }

            var employeeEmail = "employee@giftgivers.local";

            var employee =
                await userManager.FindByEmailAsync(employeeEmail);

            if (employee == null)
            {
                employee = new ApplicationUser
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    EmailConfirmed = true,
                    FullName = "Relief Coordinator"
                };

                var result = await userManager.CreateAsync(
                    employee,
                    "Employee123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(
                        employee,
                        "Employee");
                }
            }
        }
    }
}