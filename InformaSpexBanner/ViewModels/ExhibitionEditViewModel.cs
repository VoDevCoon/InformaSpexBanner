﻿using System;
using System.ComponentModel.DataAnnotations;

namespace InformaSpexBanner.ViewModels
{
	public class ExhibitionEditViewModel
	{
		public int Id{ get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public string WebUrl { get; set; }
	}
}
