using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;

namespace Obligatorio.WebApi.Services
{
	public interface IJwtGenerator
	{
		string GenerateToken(UsuarioListadoDto usuario);
	}
}
