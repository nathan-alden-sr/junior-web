using System;
using System.Configuration;
using System.Net;

using Junior.ApplicationServices;
using Junior.Common;

namespace Junior.Web
{
	/// <summary>
	/// Configuration necessary to send email messages.
	/// Configuration is initialized from a configuration section named 'emailSender'.
	/// </summary>
	public class EmailSenderConfiguration : IEmailSenderConfiguration
	{
		private readonly EmailSenderConfigurationSection _configurationSection;

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailSenderConfiguration"/> class.
		/// Configuration is initialized from a configuration section named 'emailSender'.
		/// </summary>
		public EmailSenderConfiguration()
		{
			_configurationSection = (EmailSenderConfigurationSection)ConfigurationManager.GetSection("emailSender");
		}

		/// <summary>
		/// Gets the hostname of an SMTP server.
		/// </summary>
		public string SmtpHost
		{
			get
			{
				return _configurationSection.SmtpHost;
			}
		}

		/// <summary>
		/// Gets a port for SMTP communication.
		/// </summary>
		public int SmtpPort
		{
			get
			{
				return _configurationSection.SmtpPort;
			}
		}

		/// <summary>
		/// Gets a timeout for sending email messages.
		/// </summary>
		public TimeSpan Timeout
		{
			get
			{
				return TimeSpan.FromSeconds(_configurationSection.TimeoutInSeconds);
			}
		}

		/// <summary>
		/// Gets a value indicating if SSL will be used when sending email messages.
		/// </summary>
		public bool UseSsl
		{
			get
			{
				return _configurationSection.UseSsl;
			}
		}

		/// <summary>
		/// Gets the credentials to use when authenticating with the SMTP server.
		/// </summary>
		public NetworkCredential Credentials
		{
			get
			{
				return new NetworkCredential(_configurationSection.SmtpUsername, _configurationSection.SmtpPassword);
			}
		}

		/// <summary>
		/// Gets the email address sending the email messages.
		/// </summary>
		public EmailAddress FromAddress
		{
			get
			{
				return new EmailAddress(_configurationSection.FromAddress);
			}
		}

		/// <summary>
		/// Gets the display name of the email address sending the email messages.
		/// </summary>
		public string FromAddressDisplayName
		{
			get
			{
				return _configurationSection.FromAddressDisplayName;
			}
		}
	}
}