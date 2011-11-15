using System.Web;

using Junior.ApplicationServices;

namespace Junior.Web
{
	/// <summary>
	/// Encodes and decodes URLs.
	/// </summary>
	public class UrlEncoder : IUrlEncoder
	{
		/// <summary>
		/// Encodes a URL.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>
		/// The encoded URL.
		/// </returns>
		public string Encode(string value)
		{
			return HttpUtility.UrlEncode(value);
		}

		/// <summary>
		/// Decodes a URL.
		/// </summary>
		/// <param name="value">The value to decode.</param>
		/// <returns>
		/// The decoded URL.
		/// </returns>
		public string Decode(string value)
		{
			return HttpUtility.UrlDecode(value);
		}
	}
}