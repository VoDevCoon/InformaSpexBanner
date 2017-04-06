using System;
using System.ComponentModel.DataAnnotations;

namespace InformaSpexBanner.ViewModels
{
	public class ExhibitionEditViewModel
	{
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public string WebUrl { get; set; }
		public bool Active { get; set; }
	}
}
