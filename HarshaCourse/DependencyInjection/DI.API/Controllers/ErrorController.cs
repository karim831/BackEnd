using Microsoft.AspNetCore.Mvc;

namespace DI.API.Controllers;

[Route("[controller]")]
public class ErrorController: Controller{

    [Route("{statusCode}")]
    public IActionResult Error(int statusCode){
        return View("_Error",statusCode);
    }
}