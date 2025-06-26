using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Main.Models;

namespace Main.Controllers;

public class HomeController : Controller
{
    public ContentResult ShowMsg(){
        ContentResult result = new ContentResult();
        result.Content = "Hello";
        return result;
    }

    public ViewResult ShowView(){
        ViewResult result = new ViewResult();
        result.ViewName = "View1";
        return result;
    }


    public IActionResult ShowMix(int x){
        if(x % 2 == 0)
            return View("View1");
        return Content("Hello MVC");
    }

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
