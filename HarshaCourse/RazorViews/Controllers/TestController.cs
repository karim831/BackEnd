using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using RazorViews.ViewModels.TestViewModels;

namespace RazorViews.Controllers;

[Route("[controller]")]
public class TestController: Controller{

    [HttpGet("/{id?}")]
    public IActionResult Index(int id){
        ViewBag.Message = "Your Home page.";
        return View(
            new IndexViewModel{
                Name = "Microsoft",
                Street = "One Microsoft Way",
                City = "Redmond",
                State = "WA",
                PostalCode = "98052-6399"
            }
        );
    }


}