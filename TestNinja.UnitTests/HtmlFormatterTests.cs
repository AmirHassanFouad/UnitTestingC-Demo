using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class HtmlFormatterTests
	{
		// unit test should be not too specific or too general
		[Test]
		public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
		{
			var formatter = new HtmlFormatter();

			var result = formatter.FormatAsBold("abc");

			// too specific assertion // lw 3mlt bold b ay 7aga tanya 8er el strong tag 7b2a fail
			//Assert.That(result, Is.EqualTo("<strong>abc</strong>"));

			// too general // kda lw 3mlt return "<strong>" will pass w dh msh s7
			//Assert.That(result, Does.StartWith("<strong>"));

			Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
			Assert.That(result, Does.EndWith("</strong>"));
			Assert.That(result, Does.Contain("abc"));
		}
	}
}
