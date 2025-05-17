using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio.CasoDeUsoCompartida.DTOs.Agencia;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Agencia;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.Excepciones.Envio;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.WebApp.Filtros;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
    [AuthorizeSesion]
	public class EnvioController : Controller
	{
		IAdd<EnvioDto> _add;
		IGetByName<AgenciaListadoDto> _getByNombre;
		IGetAll<EnvioListadoDto> _getAll;
		IUpdate<EnvioDto> _update;
		IGetByTracking<EnvioListadoDto> _getByTracking;
		IGetAll<AgenciaListadoDto> _getAllAgencias;


		public EnvioController(IAdd<EnvioDto> add,
							   IGetByName<AgenciaListadoDto> getByNombre,
							   IGetAll<EnvioListadoDto> getAll,
							   IUpdate<EnvioDto> update,
							   IGetByTracking<EnvioListadoDto> getByTracking,
							   IGetAll<AgenciaListadoDto> getAllAgencias)

		{
			_add = add;
			_getByNombre = getByNombre;
			_getAll = getAll;
			_update = update;
			_getByTracking = getByTracking;
			_getAllAgencias = getAllAgencias;
		}
		public IActionResult Index()
		{
			return View(_getAll.Execute());
		}

		public IActionResult Filtrar(string tipoBuscado, string estadoBuscado, DateTime? fechaInicio, DateTime? fechaFin)
		{
			var envios = _getAll.Execute();

			if (!string.IsNullOrEmpty(tipoBuscado))
				envios = envios.Where(e => e.Tipo == tipoBuscado);

			if (!string.IsNullOrEmpty(estadoBuscado))
				envios = envios.Where(e => e.Estado == estadoBuscado);

            if (fechaInicio != null && fechaFin != null)
            {
                envios = envios
                    .Where(e => e.FechaFinalizacion >= fechaInicio && e.FechaFinalizacion <= fechaFin)
                    .ToList();
            }


            return View("Index", envios);
		}


        [AuthorizeSesion]
		public IActionResult Create()
		{
			ViewBag.Agencias = _getAllAgencias.Execute()
			.Select(a => new SelectListItem { Value = a.Nombre, Text = a.Nombre });
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
            catch (EmailException e)
            {
                ViewBag.Message = e.Message;
            }
            catch (PesoException e)
            {
                ViewBag.Message = e.Message;
            }
            catch (DireccionPostalException e)
            {
                ViewBag.Message = e.Message;
            }
            catch (Exception)
			{
				ViewBag.Message = "Hubo un error";
            }
            ViewBag.Agencias = _getAllAgencias.Execute()
                   .Select(a => new SelectListItem { Value = a.Nombre, Text = a.Nombre });
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

		public IActionResult Details(int tracking)
		{
			EnvioListadoDto unE = _getByTracking.Execute(tracking);
			if (unE == null)
			{
				return RedirectToAction("index");
			}
			return View(unE);
		}


	}
}
