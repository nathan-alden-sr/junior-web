using System;
using System.Text;
using System.Web;

using Junior.ApplicationServices;
using Junior.Common;

namespace Junior.Web
{
	/// <summary>
	/// Encodes and decodes HTML.
	/// </summary>
	public class HtmlEncoder : IHtmlEncoder
	{
		private readonly INewLineReplacer _newLineReplacer;

		/// <summary>
		/// Initializes a new instance of the <see cref="HtmlEncoder"/> class.
		/// </summary>
		/// <param name="newLineReplacer">An <see cref="INewLineReplacer"/> that replaces <see cref="Environment.NewLine"/>, carriage return and line feed occurrences with BR tags.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="newLineReplacer"/> is null.</exception>
		public HtmlEncoder(INewLineReplacer newLineReplacer)
		{
			newLineReplacer.ThrowIfNull("newLineReplacer");

			_newLineReplacer = newLineReplacer;
		}

		/// <summary>
		/// Encodes HTML.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="options">Encoding options.</param>
		/// <returns>
		/// The encoded HTML.
		/// </returns>
		public string Encode(string value, HtmlEncoderOptions options = HtmlEncoderOptions.None)
		{
			if (options.HasFlag(HtmlEncoderOptions.ReplaceNewLinesWithBrTags))
			{
				value = _newLineReplacer.ReplaceWithBrTags(value);
			}

			return new StringBuilder(HttpUtility.HtmlEncode(value)).ToString();
		}

		/// <summary>
		/// Decodes HTML.
		/// </summary>
		/// <param name="value">The value to decode.</param>
		/// <returns>
		/// The decoded HTML.
		/// </returns>
		public string Decode(string value)
		{
			return HttpUtility.HtmlDecode(value);
		}
	}
}