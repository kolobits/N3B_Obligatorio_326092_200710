using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;

namespace Obligatorio.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class EnviosController : ControllerBase
	{
		IGetByTracking<EnvioListadoDto> _getByTracking;


		public EnviosController(IGetByTracking<EnvioListadoDto> getByTracking)
		{
			_getByTracking = getByTracking;
		}


		[HttpGet("{tracking}")]
		public IActionResult GetByTracking(int tracking)
		{
			try
			{
				return Ok(_getByTracking.Execute(tracking));
			}
			catch (NotFoundException e)
			{
				return StatusCode(404, $"No se encontró el número de tracking {tracking}");
			}
			catch (Exception e)
			{
				return StatusCode(500, "Hubo un problema intente nuevamente.");
			}

		}

	}
}
