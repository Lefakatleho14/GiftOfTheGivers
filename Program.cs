using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// Database Configuration
// --------------------------------------------------

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=giftgivers.db";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));


// --------------------------------------------------
// ASP.NET Core Identity Configuration
// --------------------------------------------------

builder.Services
    .AddDefaultIdentity<ApplicationUser>(options =>
    {
        // Account settings
        options.SignIn.RequireConfirmedAccount = false;

        // Password requirements
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


// --------------------------------------------------
// MVC
// --------------------------------------------------

builder.Services.AddControllersWithViews();


var app = builder.Build();


// --------------------------------------------------
// HTTP Request Pipeline
// --------------------------------------------------

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


// --------------------------------------------------
// Authentication & Authorization
// --------------------------------------------------

app.UseAuthentication();
app.UseAuthorization();


// --------------------------------------------------
// MVC Routes
// --------------------------------------------------

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// --------------------------------------------------
// ASP.NET Identity Razor Pages
// --------------------------------------------------

app.MapRazorPages();


// --------------------------------------------------
// Seed Initial Application Data
// --------------------------------------------------

using (var scope = app.Services.CreateScope())
{
    await SeedData.InitializeAsync(scope.ServiceProvider);
}


app.Run();