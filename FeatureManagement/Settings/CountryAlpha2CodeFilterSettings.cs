using System.Collections.Generic;

namespace FeatureManagement.Settings
{
	public class CountryAlpha2CodeFilterSettings
	{
		public string[] AllowedCountries { get; set; } = new string[0];
		public string[] ExcludedCountries { get; set; } = new string[0];
	}
}
