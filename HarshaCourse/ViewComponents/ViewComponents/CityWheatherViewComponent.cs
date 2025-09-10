using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

namespace ViewComponents.ViewComponents;

public class CityWeatherViewComponent: ViewComponent{
    public IViewComponentResult Invoke(CityWeather city){
        return View(city);
    }
}