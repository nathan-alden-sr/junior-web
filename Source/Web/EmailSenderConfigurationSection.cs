using System.Configuration;

using Junior.ApplicationServices;

namespace Junior.Web
{
	/// <summary>
	/// A configuration section containing configuration for the <see cref="EmailSender"/> class.
	/// </summary>
	public class EmailSenderConfigurationSection : ConfigurationSection
	{
		/// <summary>
		/// Gets or sets the hostname of an SMTP server. The configuration property is named 'smtpHost'.
		/// </summary>
		[ConfigurationProperty("smtpHost", IsRequired = true)]
		public string SmtpHost
		{
			get
			{
				return (string)this["smtpHost"];
			}
			set
			{
				this["smtpHost"] = value;
			}
		}

		/// <summary>
		/// Gets or sets a port for SMTP communication. The configuration property is named 'smtpPort'.
		/// </summary>
		[ConfigurationProperty("smtpPort", DefaultValue = 25)]
		public int SmtpPort
		{
			get
			{
				return (int)this["smtpPort"];
			}
			set
			{
				this["smtpPort"] = value;
			}
		}

		/// <summary>
		/// Gets or sets a timeout for sending email messages. The configuration property is named 'timeoutInSeconds'.
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

		/// <summary>
		/// Gets or sets a value indicating if SSL will be used when sending email messages. The configuration property is named 'useSsl'.
		/// </summary>
		[ConfigurationProperty("useSsl", DefaultValue = false)]
		public bool UseSsl
		{
			get
			{
				return (bool)this["useSsl"];
			}
			set
			{
				this["useSsl"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the username to use when authenticating with the SMTP server. The configuration property is named 'smtpUsername'.
		/// </summary>
		[ConfigurationProperty("smtpUsername", IsRequired = true)]
		public string SmtpUsername
		{
			get
			{
				return (string)this["smtpUsername"];
			}
			set
			{
				this["smtpUsername"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the password to use when authenticating with the SMTP server. The configuration property is named 'smtpPassword'.
		/// </summary>
		[ConfigurationProperty("smtpPassword", IsRequired = true)]
		public string SmtpPassword
		{
			get
			{
				return (string)this["smtpPassword"];
			}
			set
			{
				this["smtpPassword"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the email address sending the email messages. The configuration property is named 'fromAddress'.
		/// </summary>
		[ConfigurationProperty("fromAddress", IsRequired = true)]
		public string FromAddress
		{
			get
			{
				return (string)this["fromAddress"];
			}
			set
			{
				this["fromAddress"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the display name of the email address sending the email messages. The configuration property is named 'fromAddressDisplayName'.
		/// </summary>
		[ConfigurationProperty("fromAddressDisplayName")]
		public string FromAddressDisplayName
		{
			get
			{
				return (string)this["fromAddressDisplayName"];
			}
			set
			{
				this["fromAddressDisplayName"] = value;
			}
		}
	}
}