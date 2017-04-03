using System;
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
			var model = _repo.GetExhibition(Id);

			if(model!=null)
			{
				return View(model);
			}

			return NotFound();
		}
			
	}
}
