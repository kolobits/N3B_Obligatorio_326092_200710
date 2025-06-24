namespace Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios
{
	public record UsuarioLogueadoDto(
		int Id,
		string Nombre,
		string Email,
		string Token)
	{
	}
}
