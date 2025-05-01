using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Agencia;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Agencia;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.WebApp.Filtros;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
	[AuthorizeSesion]
	public class EnvioController : Controller
	{
		IAddEnvio<EnvioDto> _add;
		IGetByName<AgenciaListadoDto> _getByNombre;


		public EnvioController(IAddEnvio<EnvioDto> add, IGetByName<AgenciaListadoDto> getByNombre)

		{
			_add = add;
			_getByNombre = getByNombre;
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
				AgenciaListadoDto agencia = _getByNombre.Execute(envio.Agencia);
				_add.Execute(new EnvioDto(
											envio.Tipo,
											envio.Email,
											envio.Peso,
											agencia.Id,
											envio.Calle,
											envio.Numero,
											envio.CodigoPostal

												));
				return RedirectToAction("index");
			}

			catch (Exception e)
			{
				ViewBag.Message = "Hubo un error";
			}
			return View();

		}
	}
}
