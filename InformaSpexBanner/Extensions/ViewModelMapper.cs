﻿using System;
using System.Collections.Generic;
using InformaSpexBanner.Data;
using InformaSpexBanner.Entities;
using InformaSpexBanner.ViewModels;

namespace InformaSpexBanner.Extensions
{
	public static class ViewModelMapper
	{
		public static ExhibitionViewModel ToViewModel(this Exhibition exhibition)
		{ 
			var viewModel = new ExhibitionViewModel();
			viewModel.Id = exhibition.Id;
			viewModel.Name = exhibition.Name;
			viewModel.Description = exhibition.Description;
			viewModel.WebUrl = exhibition.WebUrl;

			var bannerViewModels = new List<BannerViewModel>();

			if (exhibition.Banners != null && exhibition.Banners.Count > 0)
			{
				foreach (var banner in exhibition.Banners)
				{
					var bannerModel = new BannerViewModel();
					bannerModel.Id = banner.Id;
					bannerModel.Name = banner.Name;
					bannerModel.ExhibitionId = banner.ExhibitionId;
					bannerModel.Text = banner.Text;
					bannerModel.ImageBase64String = String.Format("data:image;base64,{0}", Convert.ToBase64String(banner.Image));

					bannerViewModels.Add(bannerModel);
				}
			}

			viewModel.Banners = bannerViewModels;

			return viewModel;
		}

		public static BannerEditViewModel ToEditViewModel(this Banner banner)
		{
			var viewModel = new BannerEditViewModel();
			viewModel.Id = banner.Id;
			viewModel.Name = banner.Name;
			viewModel.ExhibitionId = banner.ExhibitionId;
			viewModel.ImageBase64String = String.Format("data:image;base64,{0}", Convert.ToBase64String(banner.Image));

			if (banner.Text != null)
			{
				viewModel.FixedText = banner.Text.FixedText;
				viewModel.FontColorHex = banner.Text.FontColorHex;
				viewModel.FontSize = banner.Text.FontSize;
				viewModel.FontTypeFace = banner.Text.FontTypeFace;
			}

			return viewModel;
		}
	}
}