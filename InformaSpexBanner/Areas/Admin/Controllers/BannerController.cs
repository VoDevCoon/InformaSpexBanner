using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InformaSpexBanner.Data;
using InformaSpexBanner.Entities;
using InformaSpexBanner.Extensions;
using InformaSpexBanner.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InformaSpexBanner.Admin.Controllers
{
	[Area("Admin")]
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

			var viewModel = new BannerEditViewModel();
			viewModel.ExhibitionId = exhibition.Id;
			viewModel.ExhibitionName = exhibition.Name;
			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(BannerEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var banner = new Banner();
				banner.Name = viewModel.Name;
				banner.Image = await ToImageData((viewModel.Image));
				banner.ExhibitionId = viewModel.ExhibitionId;

				//banner.Text = new CustomText
				//{
				//	FixedText = viewModel.FixedText,
				//	FontColorHex = viewModel.FontColorHex,
				//	FontSize = viewModel.FontSize,
				//	FontTypeFace = viewModel.FontTypeFace,
				//	PositionX = viewModel.PositionX,
				//	PositionY = viewModel.PositionY
				//};

				if (_repo.BannerExists(viewModel.Id))
				{
					banner = _repo.UpdateBanner(banner);
				}
				else
				{
					banner = _repo.AddBanner(banner);
				}
				    
				viewModel.Id = banner.Id;
				viewModel.ImageBase64String = String.Format("data:image;base64,{0}", Convert.ToBase64String(banner.Image));

				return View(viewModel);
			}

			return RedirectToAction("Details", "Exhibition", new { Id = viewModel.ExhibitionId });

		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var banner = _repo.GetBanner(Id);
			return View(banner.ToEditViewModel());
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
