using FeatureManagement.Enums;
using Microsoft.FeatureManagement;
using System;
using System.Threading.Tasks;

namespace FeatureManagement.Services
{
	public class WeatherForecastService : IWeatherForecastService
	{
		private readonly IFeatureManager _featureManager;
		
		public WeatherForecastService(IFeatureManager featureManager)
		{
			_featureManager = featureManager ?? throw new ArgumentNullException(nameof(IFeatureManager));
		}

		public Task<bool> ShouldAllowBlockOnRegistrationAsync(string countryAlpha2Code)
		{
			var isEnabled = _featureManager.IsEnabledAsync(nameof(FeatureFlags.ApplyBlockOnRegistration), countryAlpha2Code);

			return isEnabled;
		}

		public Task<bool> ShouldFallbackOnServiceUnavailableAsync(string countryAlpha2Code)
		{
			var isEnabled = _featureManager.IsEnabledAsync(nameof(FeatureFlags.FallbackOnServiceUnavailable), countryAlpha2Code);

			return isEnabled;
		}
	}
}
