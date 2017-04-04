using InformaSpexBanner.Data;
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

		public IActionResult Index()
		{
			var model = _repository.GetAllExhibition();
			return View(model);
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
