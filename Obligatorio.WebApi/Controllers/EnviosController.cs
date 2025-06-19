using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;

namespace Obligatorio.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EnviosController : Controller
	{
		IGetByTracking<EnvioListadoDto> _getByTracking;
		IGetAllEnviosCliente<EnvioListadoDto> _getAllEnviosCliente;

		public EnviosController(IGetByTracking<EnvioListadoDto> getByTracking, IGetAllEnviosCliente<EnvioListadoDto> getAllEnviosCliente)
		{
			_getByTracking = getByTracking;
			_getAllEnviosCliente = getAllEnviosCliente;


		}

		// RF1
		[HttpGet("{tracking}")]
		public IActionResult GetByTracking(int tracking)
		{
			try
			{
				return Ok(_getByTracking.Execute(tracking));
			}
			catch (NotFoundException e)
			{
				return StatusCode(e.statusCode(), e.Error());
			}
			catch (Exception e)
			{
				return StatusCode(500, "Hubo un problema intente nuevamente.");
			}
		}



		// RF4
		[Authorize]
		[HttpGet("listar-envios/{id}")]
		public IActionResult GetAllEnviosCliente(int id)
		{
			try
			{
				var envios = _getAllEnviosCliente.Execute(id);
				if (envios.Count() == 0)
				{
					return StatusCode(204);
				}
				return Ok(envios);
			}
			catch (NotFoundException e)
			{
				return StatusCode(e.statusCode(), e.Error());
			}
			catch (Exception e)
			{
				return StatusCode(500, "Hubo un problema intente nuevamente.");
			}
		}
	}
}


