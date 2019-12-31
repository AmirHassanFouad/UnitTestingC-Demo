using NUnit.Framework;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class MathTests
	{
		private Math _math;
		// setup
		[SetUp]
		public void SetUp()
		{
			_math = new Math();
		}

		//tearDown


		[Test]
		public void Add_WhenCalled_ReturnTheSumOfArguments()
		{
			// arrange
			//var math = new Math();

			// act
			var result = _math.Add(1, 2);

			// assert
			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
		{
			// arrange
			//var math = new Math();

			// act
			var result = _math.Max(2, 1);

			// assert
			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
		{
			// arrange
			//var math = new Math();

			// act
			var result = _math.Max(1, 2);

			// assert
			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		[Ignore("because I wanted to!")]// in change of comment this test and forget this comment later
		public void Max_ArgumentsAreEqual_ReturnTheTheSameArgument()
		{
			// arrange
			//var math = new Math();

			// act
			var result = _math.Max(2, 2);

			// assert
			Assert.That(result, Is.EqualTo(2));
		}

		// parameterized tests
		[Test]
		[TestCase(2, 1, 2)]
		[TestCase(1, 2, 2)]
		[TestCase(2, 2, 2)]
		public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
		{
			var result = _math.Max(a, b);

			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		public void GetOddNumbers_LmitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
		{
			var result = _math.GetOddNumbers(5);

			// Assert.That(result, Is.Not.Empty); // make sure result is not empty
			//Assert.That(result.Count(), Is.EqualTo(3)); // check for the count

			// check for the items inside result but ot care about the order
			//Assert.That(result, Does.Contain(1));
			//Assert.That(result, Does.Contain(3));
			//Assert.That(result, Does.Contain(5));

			// refactor to the above 3 statements
			Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

			//Assert.That(result, Is.Ordered); //the items are ordered
			//Assert.That(result, Is.Unique); // the items are not duplicated
		}
	}
}
