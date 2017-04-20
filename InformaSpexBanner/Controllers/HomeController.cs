using InformaSpexBanner.Data;
using InformaSpexBanner.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace InformaSpexBanner.Controllers
{
	public class HomeController : Controller
	{
		ISpexBannerRepository _repository;

		public HomeController(ISpexBannerRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index(int Id, string exhibitionName, string spexText)
		{
			var exhibition = _repository.GetExhibition(Id);

			if(exhibition==null||!exhibition.Name.Equals(exhibitionName))
			{
				return NotFound();
			}

			return View(exhibition.ToViewModel(spexText));
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
