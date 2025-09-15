namespace DI.Core.Models;

public class CityWeather{
    public string CityUniqueCode {get; set;} = string.Empty;
    public string CityName {get; set;} = string.Empty;
    public string DateAndTime {get; set;} = string.Empty;
    public int TemperatureFahrenheit {get; set;}
}