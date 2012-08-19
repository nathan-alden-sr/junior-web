using System;
using System.Configuration;

namespace Junior.Web
{
	/// <summary>
	/// A configuration section containing configuration for the <see cref="ReCaptchaValidatorConfiguration"/> class.
	/// </summary>
	public class ReCaptchaValidatorConfigurationSection : ConfigurationSection
	{
		/// <summary>
		/// Gets or sets the URL for which reCAPTCHA is configured. The configuration property is named 'url'.
		/// </summary>
		[ConfigurationProperty("url")]
		public Uri Url
		{
			get
			{
				return (Uri)this["url"];
			}
			set
			{
				this["url"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the reCAPTCHA public key. The configuration property is named 'publicKey'.
		/// </summary>
		[ConfigurationProperty("publicKey")]
		public string PublicKey
		{
			get
			{
				return (string)this["publicKey"];
			}
			set
			{
				this["publicKey"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the reCAPTCHA private key. The configuration property is named 'privateKey'.
		/// </summary>
		[ConfigurationProperty("privateKey")]
		public string PrivateKey
		{
			get
			{
				return (string)this["privateKey"];
			}
			set
			{
				this["privateKey"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the value of the User-Agent header when validating responses. The configuration property is named 'userAgent'.
		/// </summary>
		[ConfigurationProperty("userAgent")]
		public string UserAgent
		{
			get
			{
				return (string)this["userAgent"];
			}
			set
			{
				this["userAgent"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the amount of time before a validation request times out. The configuration property is named 'timeoutInSeconds'.
		/// </summary>
		[ConfigurationProperty("timeoutInSeconds", DefaultValue = 60)]
		public int TimeoutInSeconds
		{
			get
			{
				return (int)this["timeoutInSeconds"];
			}
			set
			{
				this["timeoutInSeconds"] = value;
			}
		}
	}
}