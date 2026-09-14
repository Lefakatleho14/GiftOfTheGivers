using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GiftOfTheGivers.Models;

namespace GiftOfTheGivers.Controllers;

public class HomeController : Controller
{
    // Home page
    public IActionResult Index()
    {
        return View();
    }

    // About page
    public IActionResult About()
    {
        return View();
    }

    // Contact page
    public IActionResult Contact()
    {
        return View();
    }

    // Privacy page
    public IActionResult Privacy()
    {
        return View();
    }

    // Error page
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}