using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class ErrorLoggerTests
	{
		private ErrorLogger _logger;

		[SetUp]
		public void SetUp()
		{
			_logger = new ErrorLogger();
		}

		[Test] // testing method that doesn't return a value
		public void Log_WhenCalled_SetTheLastErrorProperty()
		{
			_logger = new ErrorLogger();

			_logger.Log("xyz");

			Assert.That(_logger.LastError, Is.EqualTo("xyz"));

		}

		[Test] // testing method that returns an Exception scenario => by using a delegate
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		public void Log_InvalidError_ThrowArgumentNullException(string error)
		{
			_logger = new ErrorLogger();

			//_logger.Log(error);
			//using delegete
			//Assert.That(() => _logger.Log(error), Throws.TypeOf<ArgumentNullException>());
			Assert.That(() => _logger.Log(error), Throws.ArgumentNullException);

			//Assert.That(_logger.LastError, Is.EqualTo("xyz"));

		}

		[Test] // test method that raise an event
		public void Log_ValidError_RaiseErrorLoggerEvent()
		{
			_logger = new ErrorLogger();

			// before acting subscribe to that event
			var id = Guid.Empty;
			_logger.ErrorLogged += (sender, args) => { id = args; };

			_logger.Log("a");

			Assert.That(id, Is.Not.EqualTo(Guid.Empty));

		}
	}
}
