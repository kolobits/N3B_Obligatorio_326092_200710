using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;

namespace Obligatorio.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class ClientesController : ControllerBase
	{

		IGetById<UsuarioListadoDto> _getById;
		IUpdate<UsuarioDtoUpdate> _update;
		IGetAll<EnvioListadoDto> _getAll;


		public ClientesController(IUpdate<UsuarioDtoUpdate> update, IGetById<UsuarioListadoDto> getById, IGetAll<EnvioListadoDto> getAll)
		{
			_getById = getById;
			_update = update;
			_getAll = getAll;
		}

		// RF3
		[Authorize]
		[HttpPut("cambiar-password/{id}")]
		public IActionResult Update([FromBody] UsuarioDtoUpdate usuarioDtoUpdate, int id)
		{
			try
			{

				_update.Execute(id, usuarioDtoUpdate);
				return Ok();
			}
			catch (NotFoundException e)
			{
				return StatusCode(e.StatusCode(), e.Error());
			}
			catch (BadRequestException e)
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
