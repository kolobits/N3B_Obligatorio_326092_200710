using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;

namespace Obligatorio.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ILoginWebApi<UsuarioLoginDto> _login;

		public AuthController(ILoginWebApi<UsuarioLoginDto> login)
		{
			_login = login;
		}

		//RF2
		[HttpPost("login")]
		public IActionResult Login([FromBody] UsuarioLoginDto usuarioLogin)
		{
			try
			{

				if (usuarioLogin == null)
					throw new BadRequestException("Datos incompletos");
				var token = _login.Execute(usuarioLogin);
				return Ok(new { token });

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
				Error error = new Error(500, "Hubo un problema intente nuevamente." + e.Message);
				return StatusCode(500, error);
			}
		}
	}
}
