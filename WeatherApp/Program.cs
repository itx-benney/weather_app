/*
    Author : @itx-benney
	Updated In : SUN 21 May 2023
 */
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;namespace WeatherApp;

public static class Program
{
	public static void Main()
	{
		Console.WriteLine("WEATHER APP");
		Console.Write("\nEnter the city name: ");
		string cityName = Console.ReadLine();
		
		Weather.GetWeatherFrom(cityName);
	}
}
public static class Weather
{
	private static HttpClient httpClient = new HttpClient();
	private static string url = "";

	public static async void GetWeatherFrom(string cityName)
	{
		try
		{
			url = $"https://api.weatherapi.com/v1/current.json?key=93b3c27749e34d62a5982625232105&q={cityName}&aqi=no";
			string jsonResponse = await httpClient.GetStringAsync(url);
			WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);
			
			//SHOWS SOME WEATHER DATA
			Console.WriteLine("\nHere are the results: \n");
			Console.WriteLine($"CITY NAME : {weatherData.Location.Name}");
			Console.WriteLine($"COUNTRY : {weatherData.Location.Country}");
			Console.WriteLine($"LOCAL TIME : {weatherData.Location.LocalTime}");
			Console.WriteLine($"TIME ZONE : {weatherData.Location.TimeZoneId}");
			Console.WriteLine($"TEMPERATURE : {weatherData.Current.TempC} °C");
			Console.WriteLine($"CONDITION : {weatherData.Current.Condition.Text}");
			Console.WriteLine($"WIND : {weatherData.Current.WindKph} Kph");
			Console.WriteLine($"WIND DIRECTION : {weatherData.Current.WindDir}");
			Console.WriteLine($"CLOUD : {weatherData.Current.Cloud}");
			Console.WriteLine($"LAST UPDATED : {weatherData.Current.LastUpdated}");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
//CLASSES TO STORE WEATHER DATA FROM JSON
public class WeatherData
{
	public Location Location { get; set; }
	public CurrentWeather Current { get; set; }
}

public class Location
{
	public string Name { get; set; }
	public string Region { get; set; }
	public string Country { get; set; }
	public double Latitude { get; set; }
	public double Longitude { get; set; }
	public string TimeZoneId { get; set; }
	public long LocalTimeEpoch { get; set; }
	public string LocalTime { get; set; }
}

public class CurrentWeather
{
	public long LastUpdatedEpoch { get; set; }
	public string LastUpdated { get; set; }
	public double TempC { get; set; }
	public double TempF { get; set; }
	public int IsDay { get; set; }
	public Condition Condition { get; set; }
	public double WindMph { get; set; }
	public double WindKph { get; set; }
	public int WindDegree { get; set; }
	public string WindDir { get; set; }
	public double Pressure_Mb { get; set; }
	public double Pressure_In { get; set; }
	public double Precipitation_Mm { get; set; }
	public double Precipitation_In { get; set; }
	public int Humidity { get; set; }
	public int Cloud { get; set; }
	public double FeelsLikeC { get; set; }
	public double FeelsLikeF { get; set; }
	public double VisibilityKm { get; set; }
	public double VisibilityMiles { get; set; }
	public double Uv { get; set; }
	public double GustMph { get; set; }
    public double GustKph { get; set; }
}
public class Condition
{
    public string Text { get; set; }
    public string Icon { get; set; }
    public int Code { get; set; }
}