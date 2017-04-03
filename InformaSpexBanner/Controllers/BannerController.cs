using System;
using InformaSpexBanner.Data;
using InformaSpexBanner.Entities;
using InformaSpexBanner.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InformaSpexBanner
{
	public class BannerController : Controller
	{
		ISpexBannerRepository _repo;

		public BannerController(ISpexBannerRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public IActionResult Create(int Id)
		{
			var exhibition = _repo.GetExhibition(Id);

			var model = new BannerEditViewModel();
			model.ExhibitionId = exhibition.Id;
			model.ExhibitionName = exhibition.Name;
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(BannerEditViewModel model)
		{
			var banner = new Banner();
			banner.Name = model.Name;
			banner.Text = model.Text;
			banner.Image = model.Image;
			banner.ExhibitionId = model.ExhibitionId;

			banner = _repo.AddBanner(banner);
			return RedirectToAction("Details", "Exhibition", banner.ExhibitionId);
		}
	}
}
