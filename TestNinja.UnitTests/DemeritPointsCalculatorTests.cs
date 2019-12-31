using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class DemeritPointsCalculatorTests
	{
		[Test]
		public void CalculateDemritPoints_SpeedIsNegative_ThrowArgumentOutOfRangeException()
		{
			var cal = new DemeritPointsCalculator();
			Assert.That(() => cal.CalculateDemeritPoints(-180), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public void CalculateDemritPoints_GreaterThanMaxSpeed_ThrowArgumentOutOfRangeException()
		{
			var cal = new DemeritPointsCalculator();
			Assert.That(() => cal.CalculateDemeritPoints(320), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(64, 0)]
		[TestCase(65, 0)]
		[TestCase(70, 1)]
		[TestCase(75, 2)]
		public void CalculateDemritPoints_WhenCalled_RetrunDemeritPoints(int speed, int expectedResults)
		{
			var cal = new DemeritPointsCalculator();

			var result = cal.CalculateDemeritPoints(speed);

			Assert.That(result, Is.EqualTo(expectedResults));
		}
	}
}
