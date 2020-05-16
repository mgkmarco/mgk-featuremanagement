using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeatureManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FeatureManagement.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IWeatherForecastService _weatherForecastService;

		public WeatherForecastController(IWeatherForecastService weatherForecastService, ILogger<WeatherForecastController> logger)
		{
			_weatherForecastService = weatherForecastService ?? throw new ArgumentNullException(nameof(IWeatherForecastService));
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}

		[HttpGet("registration")]
		public async Task<bool> ShouldAllowBlockOnRegistrationAsync([FromQuery]string countryAlpha2Code)
		{
			var isEnabled = await _weatherForecastService.ShouldAllowBlockOnRegistrationAsync(countryAlpha2Code);

			return isEnabled;
		}

		[HttpGet("fallback")]
		public async Task<bool> ShouldFallbackOnServiceUnavailableAsync([FromQuery]string countryAlpha2Code)
		{
			var isEnabled = await _weatherForecastService.ShouldFallbackOnServiceUnavailableAsync(countryAlpha2Code);

			return isEnabled;
		}
	}
}
