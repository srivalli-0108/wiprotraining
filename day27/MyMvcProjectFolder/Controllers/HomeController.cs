using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcProject.Models;

namespace MyMvcProject.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }


    //session demo
    private const string SessionName = "_Name";
    private const string SessionAge = "_Age";
    public IActionResult Index()
    {
        //set Session data
        HttpContext.Session.SetString(SessionName, "Srivalli");
        HttpContext.Session.SetInt32(SessionAge, 22);
        return View();
    }
    public IActionResult About()
    {
        //Retrive session data
        ViewBag.Name = HttpContext.Session.GetString(SessionName);
        ViewBag.Age = HttpContext.Session.GetInt32(SessionAge);

        ViewData["Message"] = "ASP.NET Core!";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Your contact page";
        return View();
    }
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Route("number/{id:even}")]
    public IActionResult EvenCheck(int id)
    {
        return Content($"The number {id} is even.");
    }
    
}
