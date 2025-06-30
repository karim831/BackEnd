using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

public class BindController:Controller{

    //Requests

    /*
        BindingPerimitive (int, string, ...)

        Routing: /Bind/TestPerimitive?name=Vaule&&age=Value    
    */

    public IActionResult TestPerimitive(string name,int age){
        return Content($"{name} \t {age}");
    }
}