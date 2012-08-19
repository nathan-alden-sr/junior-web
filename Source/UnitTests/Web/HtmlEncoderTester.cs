using System;
using System.Text;

using Junior.ApplicationServices;

using NUnit.Framework;

using Rhino.Mocks;

namespace Junior.Web.UnitTests.Web
{
	public static class HtmlEncoderTester
	{
		public abstract class HtmlEncoderTestFixture
		{
			protected INewLineReplacer NewLineReplacer
			{
				get;
				private set;
			}

			protected HtmlEncoder SystemUnderTest
			{
				get;
				private set;
			}

			protected void SetUp()
			{
				NewLineReplacer = MockRepository.GenerateMock<INewLineReplacer>();
				SystemUnderTest = new HtmlEncoder(NewLineReplacer);
			}
		}

		[TestFixture]
		public class When_encoding_html_with_no_encoding_options : HtmlEncoderTestFixture
		{
			[Test]
			public void Must_not_replace_newlines_with_br_tags()
			{
				SetUp();

				SystemUnderTest.Encode(String.Format("\r<br/>&{0}test\n", Environment.NewLine));

				NewLineReplacer.AssertWasNotCalled(arg => arg.ReplaceWithBrTags(Arg<string>.Is.Anything));
				NewLineReplacer.AssertWasNotCalled(arg => arg.ReplaceWithBrTags(Arg<StringBuilder>.Is.Anything));
			}

			[Test]
			public void Must_perform_encoding()
			{
				SetUp();

				string encodedHtml = SystemUnderTest.Encode("<br/>&test");

				Assert.That(encodedHtml, Is.EqualTo("&lt;br/&gt;&amp;test"));
			}
		}

		[TestFixture]
		public class When_encoding_html_with_replace_new_lines_option : HtmlEncoderTestFixture
		{
			[Test]
			public void Must_replace_newlines_with_br_tags()
			{
				SetUp();

				SystemUnderTest.Encode(String.Format("\r<br/>&{0}test\n", Environment.NewLine), HtmlEncoderOptions.ReplaceNewLinesWithBrTags);

				NewLineReplacer.AssertWasCalled(arg => arg.ReplaceWithBrTags(Arg<string>.Is.Anything));
			}
		}
	}
}