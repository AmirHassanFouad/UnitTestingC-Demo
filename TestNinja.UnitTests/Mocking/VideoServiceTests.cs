using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
	[TestFixture]
	public class VideoServiceTests
	{
		private VideoService _videoService;
		private Mock<IFileReader> _fileReader;
		private Mock<IVideoRepository> _videoRepo;

		[SetUp]
		public void SetUp()
		{
			_fileReader = new Mock<IFileReader>();
			_videoRepo = new Mock<IVideoRepository>();
			_videoService = new VideoService(_fileReader.Object, _videoRepo.Object);
		}

		[Test]
		public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
		{
			_fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
			//fileReader.Setup(fr => fr.Read("video.txt")).Throws();

			var result = _videoService.ReadVideoTitle();

			Assert.That(result, Does.Contain("error").IgnoreCase);
		}

		[Test]
		public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
		{
			_videoRepo.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());
			var result = _videoService.GetUnprocessedVideosAsCsv();
			Assert.That(result, Is.EqualTo(""));
		}

		[Test]
		public void GetUnprocessedVideosAsCsv_AFewUnProcessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
		{
			_videoRepo.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video> {
				new Video{Id = 1},
				new Video{Id = 2},
				new Video{Id = 3}
			});
			var result = _videoService.GetUnprocessedVideosAsCsv();
			Assert.That(result, Is.EqualTo("1,2,3"));
		}
	}
}
