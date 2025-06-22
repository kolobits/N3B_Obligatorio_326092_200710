using Microsoft.AspNetCore.Mvc;

namespace AppCliente.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
