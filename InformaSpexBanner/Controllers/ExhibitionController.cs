using System;
using System.Collections.Generic;
using InformaSpexBanner.Data;
using InformaSpexBanner.Entities;
using InformaSpexBanner.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InformaSpexBanner.Controllers
{
	public class ExhibitionController : Controller
	{
		ISpexBannerRepository _repo;

		public ExhibitionController(ISpexBannerRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(ExhibitionEditViewModel model)
		{
			var exhibition = new Exhibition();
			exhibition.Name = model.Name;
			exhibition.Description = model.Description;
			exhibition.WebUrl = model.WebUrl;

			exhibition = _repo.AddExhibition(exhibition);

			return View("Details", exhibition);
		}

		[HttpGet]
		public IActionResult Details(int Id)
		{
			var exhibition = _repo.GetExhibition(Id);

			if(exhibition!=null)
			{

				var model = new ExhibitionViewModel();
				model.Id = exhibition.Id;
				model.Name = exhibition.Name;
				model.Description = exhibition.Description;
				model.WebUrl = exhibition.WebUrl;

				var banners = _repo.GetAllBanner(exhibition.Id);

				var bannerViewModels = new List<BannerViewModel>();
				foreach (var banner in banners)
				{
					var bannerModel = new BannerViewModel();
					bannerModel.Id = banner.Id;
					bannerModel.Name = banner.Name;
					bannerModel.ExhibitionId = banner.ExhibitionId;
					bannerModel.Text = banner.Text;
					bannerModel.ImageBase64String = String.Format("data:image;base64,{0}", Convert.ToBase64String(banner.Image));

					bannerViewModels.Add(bannerModel);
				}

				model.Banners = bannerViewModels;

				return View(model);
			}

			return NotFound();
		}
			
	}
}
