using Microsoft.AspNetCore.Mvc;
using LayoutViews.Models;

namespace LayoutViews.Controllers;

[Route("[controller]")]
public class WeatherController: Controller{
    private readonly IList<CityWeather> _cityWeathers;

    public WeatherController() => 
        _cityWeathers = [
            new CityWeather(){CityUniqueCode = "LDN", CityName = "London", DateAndTime = "2030-01-01 8:00",  TemperatureFahrenheit = 33},
            new CityWeather(){CityUniqueCode = "NYC", CityName = "London", DateAndTime = "2030-01-01 3:00",  TemperatureFahrenheit = 60},
            new CityWeather(){CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = "2030-01-01 9:00",  TemperatureFahrenheit = 82}
        ];

    [HttpGet("/")]
    public IActionResult Index() => View(_cityWeathers);
    
    [HttpGet("{citycode}")]
    public IActionResult Details([FromRoute] string citycode){
        var city = _cityWeathers.FirstOrDefault(c => c.CityUniqueCode == citycode);
        if(city == null)
            return NotFound();
        
        return View(city);

    }
}