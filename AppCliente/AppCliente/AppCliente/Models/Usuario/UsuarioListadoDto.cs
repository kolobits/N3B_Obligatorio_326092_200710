namespace AppCliente.Models.Usuario
{
	public record UsuarioListadoDto(int Id,
									string Nombre,
									string Apellido,
									string Email,
									string Token)
	{
	}
}
