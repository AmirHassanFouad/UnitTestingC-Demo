using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	// [TestClass] //MsTest
	[TestFixture] // NUnit
	public class ReservationTests
	{
		// [TestMethod] //MsTest
		[Test] // NUnit
		//          [MethodNameToBeTested]_[Scenarion]_[ExpectedBehavior]
		public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
		{

			// arrange
			var reservation = new Reservation();

			// act
			var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

			// assert
			//Assert.IsTrue(result);
			// 2 more ways to write assertion with NUnit
			Assert.That(result, Is.True);
			//Assert.That(result == true);
		}

		[Test]
		public void CanBeCancelledBy_SameUerCancellingTheReservation_ReturnsTrue()
		{

			// arrange
			var user = new User();
			var reservation = new Reservation { MadeBy = user };

			// act
			var result = reservation.CanBeCancelledBy(user);

			// assert
			Assert.IsTrue(result);
		}

		[Test]
		public void CanBeCancelledBy_AnotherUserCancellingTheReservation_ReturnsFalse()
		{

			// arrange
			var reservation = new Reservation { MadeBy = new User() };

			// act
			var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

			// assert
			Assert.IsTrue(result);
		}
	}
}
