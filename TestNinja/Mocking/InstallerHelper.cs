using System;
using System.Net;

namespace TestNinja.Mocking
{
	public class InstallerHelper
	{
		private readonly IFileDownloader _fileDownloader;
		private string _setupDestinationFile;
		public InstallerHelper(IFileDownloader fileDownloader = null)
		{
			_fileDownloader = fileDownloader ?? new FileDownloader();
		}

		public bool DownloadInstaller(string customerName, string installerName)
		{
			try
			{
				_fileDownloader.DownloadFile(string.Format("http://example.com/{0}/{1}",
						customerName,
						installerName),
						_setupDestinationFile);

				return true;
				//throw new NullReferenceException();
			}
			catch (WebException)
			{
				return false;
			}
		}
	}
}