using DI.Core.Models;

namespace DI.Core.ServiceContracts;

public interface IWeatherService{
    IList<CityWeather> GetWeatherDetails();
    CityWeather? GetWeatherByCityCode(string CityCode);
}