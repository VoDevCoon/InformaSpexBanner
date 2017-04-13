using System;
using System.IO;
using InformaSpexBanner.Entities;

namespace InformaSpexBanner.Extensions 
{
	public static class Utilities
	{
		public static void GetSpexImage(this Banner banner, string? spexText="100")
		{
			var baseImage;

			using (var ms = new MemoryStream(banner.Image))
			{
				baseImage = Image.
			}
		}
	}
}
