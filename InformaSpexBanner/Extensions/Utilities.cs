using System;
using System.IO;
using InformaSpexBanner.Entities;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace InformaSpexBanner.Extensions 
{
	public static class Utilities
	{
		public static void GetSpexImage(this Banner banner, string spexText)
		{

			using (var ms = new MemoryStream(banner.Image))
			{
				Bitmap baseImage = new Bitmap(ms);
				Bitmap tempImage = new Bitmap(baseImage.Width, baseImage.Height);

				using (Graphics image = Graphics.FromImage(tempImage))

				{
					using (SolidBrush brush = new SolidBrush((ColorTranslator.FromHtml(banner.Text.FontColorHex))))
					{
						image.SmoothingMode = SmoothingMode.AntiAlias;
						image.DrawImage(baseImage, 0, 0);
						image.DrawString(banner.Text.FixedText + spexText, new Font(banner.Text.FontTypeFace, banner.Text.FontSize, FontStyle.Regular), brush, new Point(banner.Text.PositionX, banner.Text.PositionY));
					}
				}

				ImageConverter converter = new ImageConverter();
				banner.Image = (byte[])converter.ConvertTo(tempImage, typeof(byte[]));
			}
		}

	}
}
