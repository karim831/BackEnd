namespace RazorViews.Models;

public class CityWeather{
    public string CityUniqueCode {get; set;} = null!;
    public string CityName {get; set;} = null!;
    public string DateAndTime {get; set;} = null!;
    public int TemperatureFahrenheit {get; set;}
}