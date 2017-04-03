using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InformaSpexBanner.Data;
using InformaSpexBanner.Entities;
using InformaSpexBanner.ViewModels;
using Microsoft.AspNetCore.Http;
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
		public async Task<IActionResult> Create(BannerEditViewModel model)
		{
			if (ModelState.IsValid)
			{
				var banner = new Banner();
				banner.Name = model.Name;
				banner.Image = await ToImageData((model.Image));
				banner.ExhibitionId = model.ExhibitionId;

				banner.Text = new CustomText
				{
					FixedText = model.FixedText,
					FontColorHex = model.FontColorHex,
					FontSize = model.FontSize,
					FontTypeFace = model.FontTypeFace,
					PositionX = model.PositionX,
					PositionY = model.PositionY
				};

				banner = _repo.AddBanner(banner);
			}

			return RedirectToAction("Details", "Exhibition", new { Id = model.ExhibitionId });

		}


		private async Task<byte[]> ToImageData(IFormFile file)
		{
			var stream = file.OpenReadStream();

			using (var memoryStream = new MemoryStream())
			{
				await stream.CopyToAsync(memoryStream);
				return memoryStream.ToArray();
			}
		}
	}
}
