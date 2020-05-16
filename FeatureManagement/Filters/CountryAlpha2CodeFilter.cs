using System.Linq;
using System.Threading.Tasks;
using FeatureManagement.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace FeatureManagement.Filters
{
	[FilterAlias("CountryAlpha2Code")]
	public class CountryAlpha2CodeFilter : IContextualFeatureFilter<string>
	{
		/// <summary>
		/// Evaluate a condition based on the appContxet representing a CountryAlpha2Code
		/// </summary>
		/// <param name="featureFilterContext"></param>
		/// <param name="appContext"></param>
		/// <returns></returns>
		public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext featureFilterContext, string appContext)
		{
			var settings = featureFilterContext.Parameters.Get<CountryAlpha2CodeFilterSettings>();

			if(!settings.ExcludedCountries.Any(x => string.Equals(x, appContext, System.StringComparison.OrdinalIgnoreCase)))
			{
				return Task.FromResult(settings.AllowedCountries.Any(x => string.Equals(x, appContext, System.StringComparison.OrdinalIgnoreCase)));
			}

			return Task.FromResult(false);
		}
	}
}
