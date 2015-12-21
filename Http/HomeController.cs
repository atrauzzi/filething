namespace FileThing.Http {

	using Microsoft.AspNet.Http;
	using Microsoft.AspNet.Mvc;


	public class HomeController : Controller {

		public IActionResult Index() {

			return View();

		}

		public IActionResult Upload(HomeUploadModel uploadModel) {

			return View(uploadModel);

		}

	}

}
