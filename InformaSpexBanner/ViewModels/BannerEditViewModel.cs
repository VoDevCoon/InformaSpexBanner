using System.ComponentModel.DataAnnotations;
using InformaSpexBanner.Entities;
using Microsoft.AspNetCore.Http;

namespace InformaSpexBanner.ViewModels
{
	public class BannerEditViewModel
	{
		[Required]
		public string Name { get; set; }
		public int ExhibitionId { get; set; }
		public IFormFile Image { get; set; }
		public string ExhibitionName { get; set; }

		public string FixedText { get; set; }
		public int FontSize { get; set; }
		public string FontColorHex { get; set; }
		public string FontTypeFace { get; set; }
		public int PositionX { get; set; }
		public int PositionY { get; set; }
	}
}