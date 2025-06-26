using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Seguimiento;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
namespace Obligatorio.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EnviosController : Controller
	{
		IGetByTracking<EnvioListadoDto> _getByTracking;
		IGetAllEnviosCliente<EnvioListadoDto> _getAllEnviosCliente;
		IGetEnviosFecha<EnvioListadoDto> _getEnviosFecha;
		IGetEnviosComentario<EnvioListadoDto> _getEnviosComentario;
		IGetSeguimientosEnvio _getSeguimientosEnvio;
		public EnviosController(IGetByTracking<EnvioListadoDto> getByTracking, IGetAllEnviosCliente<EnvioListadoDto> getAllEnviosCliente, IGetEnviosFecha<EnvioListadoDto> getEnviosFecha, IGetEnviosComentario<EnvioListadoDto> getEnviosComentario, IGetSeguimientosEnvio getSeguimientosEnvio)
		{
			_getByTracking = getByTracking;
			_getAllEnviosCliente = getAllEnviosCliente;
			_getEnviosFecha = getEnviosFecha;
			_getEnviosComentario = getEnviosComentario;
			_getSeguimientosEnvio = getSeguimientosEnvio;
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
				return StatusCode(e.StatusCode(), e.Error());
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
				return StatusCode(e.StatusCode(), e.Error());
			}
			catch (Exception e)
			{
				return StatusCode(500, "Hubo un problema intente nuevamente.");
			}
		}

		[Authorize]
		[HttpGet("{id}/seguimientos")]
		public IActionResult GetSeguimientosDeEnvio(int id)
		{
			try
			{
				var seguimientos = _getSeguimientosEnvio.Execute(id);
				if (seguimientos.Count() == 0)
				{
					return StatusCode(204);
				}
				return Ok(seguimientos);
			}
			catch (NotFoundException e)
			{
				return StatusCode(e.StatusCode(), e.Error());
			}
			catch (Exception e)
			{
				return StatusCode(500, "Hubo un problema intente nuevamente.");
			}
		}

        //RF5
        [Authorize]
        [HttpGet("listar-enviosFecha/{id}")]
        public IActionResult GetAllEnviosFecha(DateTime? fechaInicio, DateTime? fechaFin, string estado, int id)
        {
            try
            {
                var envios = _getEnviosFecha.Execute(fechaInicio, fechaFin, estado, id);
                if (envios.Count() == 0)
                {
                    return StatusCode(204);
                }
                return Ok(envios);
            }
            catch (NotFoundException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Hubo un problema intente nuevamente.");
            }
        }

        // RF6
        [Authorize]
        [HttpGet("listar-enviosComentario/{id}")]
        public IActionResult GetEnviosComentario(string comentario, int id)
        {
            try
            {
                var envios = _getEnviosComentario.Execute(comentario, id);
                if (envios.Count() == 0)
                {
                    return StatusCode(204);
                }
                return Ok(envios);
            }
            catch (NotFoundException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Hubo un problema intente nuevamente.");
            }
        }
    }
}


