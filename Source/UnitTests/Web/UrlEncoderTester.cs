using NUnit.Framework;

namespace Junior.Web.UnitTests.Web
{
	public static class UrlEncoderTester
	{
		[TestFixture]
		public class When_decoding_url
		{
			[Test]
			public void Must_perform_decoding()
			{
				var systemUnderTest = new UrlEncoder();
				string decodedUrl = systemUnderTest.Decode("%3fTest%3d1%26Test%3d2%0d");

				Assert.That(decodedUrl, Is.EqualTo("?Test=1&Test=2\r"));
			}
		}

		[TestFixture]
		public class When_encoding_url
		{
			[Test]
			public void Must_perform_encoding()
			{
				var systemUnderTest = new UrlEncoder();
				string encodedUrl = systemUnderTest.Encode("?Test=1&Test=2\r");

				Assert.That(encodedUrl, Is.EqualTo("%3fTest%3d1%26Test%3d2%0d"));
			}
		}
	}
}