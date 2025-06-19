using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
using Obligatorio.WebApi.Services;

namespace Obligatorio.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IJwtGenerator _jwtGenerator;
		private readonly ILogin<UsuarioListadoDto> _login;

		public AuthController(IJwtGenerator jwtGenerator,
							  ILogin<UsuarioListadoDto> login)
		{
			_login = login;
			_jwtGenerator = jwtGenerator;
		}


		[HttpPost("login")]
		public IActionResult Login([FromBody] UsuarioLoginDto usuarioLogin)
		{
			try
			{

				if (usuarioLogin == null)
				{
					throw new BadRequestException("Datos incompletos");
				}
				var usuario = _login.Execute(usuarioLogin.Email, usuarioLogin.Password);
				var token = _jwtGenerator.GenerateToken(usuario);
				return Ok(new { token });
			}
			catch (BadRequestException e)
			{
				return StatusCode(400, e.Message);
			}
			catch (Exception e)
			{
				return StatusCode(500, "Hubo un problema intente nuevamente.");
			}
		}
	}
}
