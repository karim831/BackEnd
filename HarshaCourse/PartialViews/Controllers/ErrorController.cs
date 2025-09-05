using Microsoft.AspNetCore.Mvc;

namespace PartialViews.Controllers;

[Route("[controller]")]
public class ErrorController: Controller{

    public IActionResult Error(){
        return View("_Error");
    }
}