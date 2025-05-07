using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Agencia;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Agencia;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.WebApp.Filtros;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
	[AuthorizeSesion]
	public class EnvioController : Controller
	{
		IAddEnvio<EnvioDto> _add;
		IGetByName<AgenciaListadoDto> _getByNombre;
		IGetAll<EnvioListadoDto> _getAll;
		IUpdate<EnvioDto> _update;


		public EnvioController(IAddEnvio<EnvioDto> add, IGetByName<AgenciaListadoDto> getByNombre, IGetAll<EnvioListadoDto> getAll, IUpdate<EnvioDto> update)

		{
			_add = add;
			_getByNombre = getByNombre;
			_getAll = getAll;
			_update = update;

		}
		public IActionResult Index()
		{
			return View(_getAll.Execute());
		}

		public IActionResult Filtrar(string tipoBuscado, string estadoBuscado)
		{
			var envios = _getAll.Execute();

			if (!string.IsNullOrEmpty(tipoBuscado))
				envios = envios.Where(e => e.Tipo == tipoBuscado);

			if (!string.IsNullOrEmpty(estadoBuscado))
				envios = envios.Where(e => e.Estado == estadoBuscado);

			return View("Index", envios);
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
				if (envio.Tipo == "Comun")
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
				}
				else if (envio.Tipo == "Urgente")
				{
					_add.Execute(new EnvioDto(
											   envio.Tipo,
											   envio.Email,
											   envio.Peso,
											   null,
											   envio.Calle,
											   envio.Numero,
											   envio.CodigoPostal
												));
				}

				return RedirectToAction("index");
			}

			catch (Exception e)
			{
				ViewBag.Message = "Hubo un error";
			}
			return View();

		}

		[HttpPost]
		public IActionResult Finalizar(int id, EnvioDto dto)
		{
			try
			{
				_update.Execute(id, dto);
				return RedirectToAction("Index");
			}
			catch (Exception e)
			{
				ViewBag.Message = $"Error al finalizar el envío: {e.Message}";
				return RedirectToAction("Index");
			}
		}
	}
}
