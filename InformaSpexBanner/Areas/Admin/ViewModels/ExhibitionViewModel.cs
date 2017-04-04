using System.Collections.Generic;
using InformaSpexBanner.Entities;

namespace InformaSpexBanner.ViewModels
{
	public class ExhibitionViewModel
	{
		public int Id{ get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string WebUrl { get; set; }
		public IEnumerable<BannerViewModel> Banners { get; set; }
	}
}
