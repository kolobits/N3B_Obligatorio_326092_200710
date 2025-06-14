using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class ClienteController : ControllerBase
	{
		IGetByTracking<EnvioListadoDto> _getByTracking;
		IGetById<UsuarioListadoDto> _getById;
		IUpdate<UsuarioDto> _update;
		IGetAll<EnvioListadoDto> _getAll;


		public ClienteController(IGetByTracking<EnvioListadoDto> getByTracking, IUpdate<UsuarioDto> update, IGetById<UsuarioListadoDto> getById, IGetAll<EnvioListadoDto> getAll)
		{
			_getByTracking = getByTracking;
			_getById = getById;
			_update = update;
			_getAll = getAll;
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

		// RF2


		// RF3
		[HttpGet("update/{id}")]
		public IActionResult Update(int id)
		{
			try
			{
				var usuario = new VMUsuario { Password = "" };

				return Ok(_getById.Execute(id));
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

		[HttpPut("{id}")]
		public IActionResult Update([FromBody] UsuarioDto usuarioDto, int id) // Creamos caso de uso nuevo? Dto nuevo? o reutilizamos el existente?
		{
			try
			{
				_update.Execute(id, usuarioDto);
				return Ok("Usuario actualizado correctamente.");
			}
			catch (NotFoundException e)
			{
				return StatusCode(e.statusCode(), e.Error());
			}
			catch (BadRequestException e)
			{
				return StatusCode(e.statusCode(), e.Error());
			}
			catch (Exception e)
			{
				return StatusCode(500, "Hubo un problema intente nuevamente.");
			}
		}


		// RF4

		[HttpGet]
		public IActionResult GetAll() // Crear nuevo CU con los envios del cliente logueado para poder controlar con sesion?
		{
			try
			{
				var envios = _getAll.Execute();

				if (envios.Count() == 0)
				{
					return StatusCode(204);
				}

				return Ok(envios);
			}
			catch (Exception e)
			{
				return StatusCode(500, "Hubo un problema intente nuevamente.");
			}
		}

	}
}
