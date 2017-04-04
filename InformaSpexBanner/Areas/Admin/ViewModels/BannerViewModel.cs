using System;
using InformaSpexBanner.Entities;

namespace InformaSpexBanner.ViewModels
{
	public class BannerViewModel
	{
		public int Id { get; set; }
		public string ImageBase64String { get; set; }
		public string Name { get; set; }
		public int ExhibitionId { get; set; }
		public CustomText Text { get; set; }
	}
}
