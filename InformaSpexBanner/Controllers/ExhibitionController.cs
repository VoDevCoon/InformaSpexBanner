using System;
using System.Collections.Generic;
using InformaSpexBanner.Data;
using InformaSpexBanner.Entities;
using InformaSpexBanner.Extensions;
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
            exhibition.Active = model.Active;

			exhibition = _repo.AddExhibition(exhibition);

			return View("Details", exhibition.ToViewModel());
		}

		[HttpGet]
		public IActionResult Details(int Id)
		{
			var exhibition = _repo.GetExhibition(Id);

			if(exhibition!=null)
			{
				return View(exhibition.ToViewModel());
			}

			return NotFound();
		}

		[HttpGet]
		public IActionResult ChangeStatus(int Id)
		{
			var exhibition = _repo.GetExhibition(Id);
			exhibition.Active = !exhibition.Active;

			_repo.UpdateExhition(exhibition);

			return RedirectToAction("Index", "Home", null);
		}

		[HttpGet]
		public IActionResult Delete(int Id)
		{
			var exhibition = _repo.GetExhibition(Id);
			if(exhibition==null)
			{
				return NotFound();
			}

			return View(exhibition.ToViewModel());
		}

		[HttpPost]
		public IActionResult Delete(int Id, string name)
		{
			_repo.DeleteExhibition(Id, name);

			return RedirectToAction("Index","Home",null);
		}
			
	}
}
