using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class EmployeeControllerTests
	{
		[Test]
		public void DeleteEmployee_WhenCalled_DeleteTheEmplyeeFromDb()
		{
			var storage = new Mock<IEmployeeStorage>();
			var controller = new EmployeeController(storage.Object);

			controller.DeleteEmployee(1);

			storage.Verify(s => s.DeleteEmployee(1));
		}

		[Test]
		public void DeleteEmployee_WhenCalled_ReturnRedirectResult()
		{
			// GetCustomer returning RedirectResult (return a value)
			var storage = new Mock<IEmployeeStorage>();
			var controller = new EmployeeController(storage.Object);

			var result = controller.DeleteEmployee(1);

			// Assert.That(result, Is.InstanceOf<RedirectResult>()); // means if result is of RedirectResult object or one of its derivatives

			Assert.That(result, Is.TypeOf<RedirectResult>());// means if result is exactly of RedirectResult object 
		}
	}
}
