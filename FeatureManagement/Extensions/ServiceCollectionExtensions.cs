using FeatureManagement.Filters;
using FeatureManagement.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace FeatureManagement.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddTransient<IWeatherForecastService, WeatherForecastService>();
		}

		public static void AddFeatureFlagManagement(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddFeatureManagement()
				.AddFeatureFilter<CountryAlpha2CodeFilter>();			
		}
	}
}
