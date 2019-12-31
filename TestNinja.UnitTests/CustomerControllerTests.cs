using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class CustomerControllerTests
	{
		[Test]
		public void GetCustomer_IdIsZero_ReturnNotFound()
		{
			// GetCustomer returning IActionResult (return a value)
			var customerController = new CustomerController();

			var result = customerController.GetCustomer(0);

			// Assert.That(result, Is.InstanceOf<NotFound>()); // means if result is of NotFound object or one of its derivatives

			Assert.That(result, Is.TypeOf<NotFound>());// means if result is exactly of NotFound object 
		}

		[Test]
		public void GetCustomer_IdIsNotZero_ReturnOk()
		{
			// GetCustomer returning IActionResult
			var customerController = new CustomerController();

			var result = customerController.GetCustomer(1);

			// Assert.That(result, Is.InstanceOf<NotFound>()); // means if result is of NotFound object or one of its derivatives

			Assert.That(result, Is.TypeOf<Ok>());// means if result is exactly of NotFound object 
		}
	}
}
