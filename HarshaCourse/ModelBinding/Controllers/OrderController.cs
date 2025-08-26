using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBinding.Models.Entities;

namespace ModelBinding.Controllers;


[Route("[controller]")]
public class OrderController: Controller{

    [HttpPost]
    public IActionResult Index([FromForm] Order order){
        if(!ModelState.IsValid){
            string errors = string.Join(",\n",
                ModelState.Values
                .SelectMany(value => value.Errors)
                .Select(error => error.ErrorMessage)
            );
            return BadRequest(errors);
        }
        order.OrderNo = new Random().Next(1,100000);
        return Json(new{orderNumber = order.OrderNo});
    }
}