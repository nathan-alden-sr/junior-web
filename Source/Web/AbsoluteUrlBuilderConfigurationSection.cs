using System;
using System.Configuration;

namespace Junior.Web
{
	/// <summary>
	/// A configuration section containing configuration for the <see cref="AbsoluteUrlBuilderConfiguration"/> class.
	/// </summary>
	public class AbsoluteUrlBuilderConfigurationSection : ConfigurationSection
	{
		/// <summary>
		/// Gets or sets a root URL. The configuration property is named 'rootUrl'.
		/// </summary>
		[ConfigurationProperty("rootUrl")]
		public Uri RootUrl
		{
			get
			{
				return (Uri)this["rootUrl"];
			}
			set
			{
				this["rootUrl"] = value;
			}
		}
	}
}