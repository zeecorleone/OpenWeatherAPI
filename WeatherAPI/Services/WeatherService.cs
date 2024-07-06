namespace WeatherAPI.Services;

public class WeatherService : IWeatherService
{
	private readonly HttpClient _httpClient;
	private readonly string _apiKey;

	public WeatherService(HttpClient httpClient)
	{
		_httpClient = httpClient;
		_apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY");
	}

	public async Task<string> GetWeather(string city)
	{
		var url = $"data/2.5/weather?q={city}&appid={_apiKey}";
		var response = await _httpClient.GetAsync(url);
		if (response.IsSuccessStatusCode)
		{
			return await response.Content.ReadAsStringAsync();
		}
		return null;
	}
}

public interface IWeatherService
{
	Task<string> GetWeather(string city);
}