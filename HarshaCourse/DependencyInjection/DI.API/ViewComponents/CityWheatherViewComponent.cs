using Microsoft.AspNetCore.Mvc;
using DI.Core.Models;

namespace DI.API.ViewComponents;

public class CityWeatherViewComponent: ViewComponent{
    public IViewComponentResult Invoke(CityWeather city){
        return View(city);
    }
}