using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.WebApp.Filtros;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
	[AuthorizeSesion]
	public class EnvioController : Controller
	{
		IAddEnvio<EnvioDto> _add;


		public EnvioController(IAddEnvio<EnvioDto> add)

		{
			_add = add;
		}
		public IActionResult Index()
		{
			return View();
		}

		[AuthorizeSesion]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(VMEnvio envio)
		{
			try
			{
				_add.Execute(new EnvioDto(
											envio.Tipo,
											envio.Email,
											envio.Peso,
											envio.Agencia,
											envio.Calle,
											envio.Numero,
											envio.CodigoPostal

												));
				return RedirectToAction("index");
			}

			catch (Exception)
			{
				ViewBag.Message = "Hubo un error";
			}
			return View();

		}
	}
}
