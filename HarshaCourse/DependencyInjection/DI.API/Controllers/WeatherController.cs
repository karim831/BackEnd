using System.Net;
using DI.Core.Models;
using DI.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
namespace DI.API.Controllers;

[Route("[controller]")]
public class WeatherController: Controller{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService) => _weatherService = weatherService;
 

    [HttpGet("/")]
    public IActionResult Index() => View(_weatherService.GetWeatherDetails());
    
    [HttpGet("{citycode}")]
    public IActionResult Details([FromRoute] string citycode){
        try{
            var city = _weatherService.GetWeatherByCityCode(citycode);
            if(city == null)
                return NotFound();
            return View(city);
        }catch(Exception){
            return Redirect($"/error/{HttpStatusCode.InternalServerError}");
        }
    }


    
}