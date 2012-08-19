using System;
using System.Configuration;

using Junior.ApplicationServices;

namespace Junior.Web
{
	/// <summary>
	/// Configuration necessary to validate reCAPTCHA responses.
	/// Configuration is initialized from a configuration section named 'reCaptchaValidator'.
	/// </summary>
	public class ReCaptchaValidatorConfiguration : IReCaptchaValidatorConfiguration
	{
		private readonly ReCaptchaValidatorConfigurationSection _configurationSection;

		/// <summary>
		/// Initializes a new instance of the <see cref="ReCaptchaValidatorConfiguration"/> class.
		/// Configuration is initialized from a configuration section named 'reCaptchaValidator'.
		/// </summary>
		public ReCaptchaValidatorConfiguration()
		{
			_configurationSection = (ReCaptchaValidatorConfigurationSection)ConfigurationManager.GetSection("reCaptchaValidator");
		}

		/// <summary>
		/// Gets the URL for which reCAPTCHA is configured.
		/// </summary>
		public Uri Url
		{
			get
			{
				return _configurationSection.Url;
			}
		}

		/// <summary>
		/// Gets the reCAPTCHA public key.
		/// </summary>
		public string PublicKey
		{
			get
			{
				return _configurationSection.PublicKey;
			}
		}

		/// <summary>
		/// Gets the reCAPTCHA private key.
		/// </summary>
		public string PrivateKey
		{
			get
			{
				return _configurationSection.PrivateKey;
			}
		}

		/// <summary>
		/// Gets the value of the User-Agent header when validating responses.
		/// </summary>
		public string UserAgent
		{
			get
			{
				return _configurationSection.UserAgent;
			}
		}

		/// <summary>
		/// Gets the amount of time before a validation request times out.
		/// </summary>
		public TimeSpan Timeout
		{
			get
			{
				return TimeSpan.FromSeconds(_configurationSection.TimeoutInSeconds);
			}
		}
	}
}