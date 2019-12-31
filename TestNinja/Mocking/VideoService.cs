using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
	public class VideoService
	{
		private readonly IFileReader _reader;
		private readonly IVideoRepository _videoRepository;

		public VideoService(IFileReader reader = null, IVideoRepository videoRepository = null)
		{
			_reader = reader ?? new FileReader(); // because I don't use a DI framework
			_videoRepository = videoRepository ?? new VideoRepository();
		}

		public string ReadVideoTitle()
		{
			var str = _reader.Read("video.txt");
			var video = JsonConvert.DeserializeObject<Video>(str);
			if (video == null)
				return "Error parsing the video.";
			return video.Title;
		}

		public string GetUnprocessedVideosAsCsv()
		{
			var videoIds = new List<int>();

			foreach (var v in _videoRepository.GetUnprocessedVideos())
				videoIds.Add(v.Id);

			return String.Join(",", videoIds);

		}
	}

	public class Video
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public bool IsProcessed { get; set; }
	}

	public class VideoContext : DbContext
	{
		public DbSet<Video> Videos { get; set; }
	}
}