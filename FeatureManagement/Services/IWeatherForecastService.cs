using System.Threading.Tasks;

namespace FeatureManagement.Services
{
	public interface IWeatherForecastService
	{
		Task<bool> ShouldAllowBlockOnRegistrationAsync(string countryAlpha2Code);
		Task<bool> ShouldFallbackOnServiceUnavailableAsync(string countryAlpha2Code);
	}
}
