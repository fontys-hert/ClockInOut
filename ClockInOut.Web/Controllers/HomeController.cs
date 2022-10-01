using ClockInOut.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

//1.Ask for the name
//2.Show at which time he clocked in
//3.Keep asking for the name again
//4a.When a different name is input-> 2
//4b.When clocked in name is given-> 5
//4c.When no name is supplied-> 6
//5.Show date clocked out
//6.Show message that name has to be given-> 1
//7.After clocking in or out, show who's still clocked in
//8. (Bonus) show the clock duration when clocking out

namespace ClockInOut.Web.Controllers;

// tutorial link: https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-6.0

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(ClockViewModel viewModel)
    {
        if (!ModelState.IsValid) return View();

        viewModel.DateClocked = DateTime.Now;

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}