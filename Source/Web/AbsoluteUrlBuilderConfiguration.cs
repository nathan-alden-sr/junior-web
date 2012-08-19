using System;
using System.Configuration;

using Junior.ApplicationServices;

namespace Junior.Web
{
	/// <summary>
	/// Configuration necessary to build absolute URLs.
	/// Configuration is initialized from a configuration section named 'absoluteUrlBuilder'.
	/// </summary>
	public class AbsoluteUrlBuilderConfiguration : IAbsoluteUrlBuilderConfiguration
	{
		private readonly AbsoluteUrlBuilderConfigurationSection _configurationSection;

		/// <summary>
		/// Initializes a new instance of the <see cref="AbsoluteUrlBuilderConfiguration"/> class.
		/// Configuration is initialized from a configuration section named 'absoluteUrlBuilder'.
		/// </summary>
		public AbsoluteUrlBuilderConfiguration()
		{
			_configurationSection = (AbsoluteUrlBuilderConfigurationSection)ConfigurationManager.GetSection("absoluteUrlBuilder");
		}

		/// <summary>
		/// Gets a root URL.
		/// </summary>
		public Uri RootUrl
		{
			get
			{
				return _configurationSection.RootUrl;
			}
		}
	}
}