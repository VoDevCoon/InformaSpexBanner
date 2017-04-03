using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using InformaSpexBanner.Entities;

namespace InformaSpexBanner.ViewModels
{
	public class BannerEditViewModel
	{
		[Required]
		public string Name { get; set; }
		public int ExhibitionId { get; set; }
		public FileStream Image { get; set; }
		public CustomText Text { get; set; }
		public string ExhibitionName { get; set; }
	}
}
