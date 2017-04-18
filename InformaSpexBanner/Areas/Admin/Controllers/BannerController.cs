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
				banner.Text = new CustomText();

				banner = _repo.AddBanner(banner);

				    
				//viewModel.Id = banner.Id;
				//viewModel.ImageBase64String = String.Format("data:image;base64,{0}", Convert.ToBase64String(banner.Image));

				return RedirectToAction("Edit", new { Id = banner.Id });
			}

			return View(viewModel);

		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var banner = _repo.GetBanner(Id);
			return View(banner.ToEditViewModel());
		}


		[HttpPost]
		public IActionResult Edit(BannerEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var banner = _repo.GetBanner(viewModel.Id);
				banner.Name = viewModel.Name;
				banner.ExhibitionId = viewModel.ExhibitionId;


				banner.Text.FixedText = viewModel.FixedText;
				banner.Text.FontColorHex = viewModel.FontColorHex;
				banner.Text.FontSize = viewModel.FontSize;
				banner.Text.FontTypeFace = viewModel.FontTypeFace;
				banner.Text.PositionX = viewModel.PositionX;
				banner.Text.PositionY = viewModel.PositionY;
			

				banner = _repo.UpdateBanner(banner);

				return RedirectToAction("Details", new { Id = banner.Id });
			}

			return View(viewModel);
		}

		[HttpGet]
		public IActionResult Details(int Id, string spexText="test")
		{
			var banner = _repo.GetBanner((Id));

			banner.GetSpexImage(spexText);

			return View(banner.ToViewModel());
		}

		[HttpGet]
		public IActionResult Delete(int Id)
		{
			var banner = _repo.GetBanner(Id);

			if(banner==null)
			{
				return NotFound();
			}

			banner.GetSpexImage();

			return View(banner.ToViewModel());
		}

		[HttpPost]
		public IActionResult Delete(int Id, int ExhibitionId)
		{
			if(_repo.BannerExists(Id))
			{
				_repo.DeleteBanner(Id);
			}

			return RedirectToAction("Details","Exhibition", new { Id = ExhibitionId });
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
