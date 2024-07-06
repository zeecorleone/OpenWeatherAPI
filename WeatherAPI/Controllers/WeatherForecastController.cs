using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly string _apiKey;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IWeatherService _weatherService;

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory, IWeatherService weatherService)
		{
			_logger = logger;
			_apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY");
			_httpClientFactory = httpClientFactory;
			_weatherService = weatherService;
		}

		/// <summary>
		/// Gets weather info from OpenWeather API using classing HttpClient approach
		/// </summary>
		/// <param name="city"></param>
		/// <returns></returns>
		[HttpGet("GetOpenWeather")]
		public async Task<string> GetOpenWeather(string city)
		{
			using (var httpClient = new HttpClient())
			{
				var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}"; 
				var response = await httpClient.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					return await response.Content.ReadAsStringAsync();
				}

				return null;
			}
		}

		/// <summary>
		/// Gets weather info from OpenWeather API using IHttpClientFacotry injected
		/// </summary>
		/// <param name="city"></param>
		/// <returns></returns>
		[HttpGet("GetOpenWeatherV1")]
		public async Task<string> GetOpenWeatherV1(string city)
		{
			var httpClient = _httpClientFactory.CreateClient();
			var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}";

			var response = await httpClient.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadAsStringAsync();
			}
			return null;
		}

		/// <summary>
		/// Gets weather info from OpenWeather API using IHttpClientFacotry named clients
		/// </summary>
		/// <param name="city"></param>
		/// <returns></returns>
		[HttpGet("GetOpenWeatherV2")]
		public async Task<string> GetOpenWeatherV2(string city)
		{
			var httpClient = _httpClientFactory.CreateClient("WeatherClient"); //configured in program.cs

			var url = $"data/2.5/weather?q={city}&appid={_apiKey}";

			var response = await httpClient.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadAsStringAsync();
			}
			return null;
		}

		/// <summary>
		/// Gets weather info from OpenWeather API using IHttpClientFacotry typed client approach
		/// </summary>
		/// <param name="city"></param>
		/// <returns></returns>
		[HttpGet("GetOpenWeatherV3")]
		public async Task<string> GetOpenWeatherV3(string city)
		{
			return await _weatherService.GetWeather(city);
		}
	}
}
