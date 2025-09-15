using DI.Core.Models;
using DI.Core.ServiceContracts;

namespace DI.Infrastructure.ServiceImplementations;

public class WeatherService: IWeatherService{
    
    private readonly IEnumerable<CityWeather> _cityWeathers;

    public WeatherService(){
        _cityWeathers =  [
            new CityWeather(){CityUniqueCode = "LDN", CityName = "London", DateAndTime = "2030-01-01 8:00",  TemperatureFahrenheit = 33},
            new CityWeather(){CityUniqueCode = "NYC", CityName = "London", DateAndTime = "2030-01-01 3:00",  TemperatureFahrenheit = 60},
            new CityWeather(){CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = "2030-01-01 9:00",  TemperatureFahrenheit = 82}
        ];
    }
    public IList<CityWeather> GetWeatherDetails(){
        return _cityWeathers.ToList();
    }
    public CityWeather? GetWeatherByCityCode(string CityCode){
        return _cityWeathers.FirstOrDefault(c => c.CityUniqueCode == CityCode);
    }
}