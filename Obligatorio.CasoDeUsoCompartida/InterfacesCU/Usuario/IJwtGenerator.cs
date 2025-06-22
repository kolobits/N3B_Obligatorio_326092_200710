using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;

namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario
{
	public interface IJwtGenerator
	{
		string GenerateToken(UsuarioListadoDto usuario);
	}
}
