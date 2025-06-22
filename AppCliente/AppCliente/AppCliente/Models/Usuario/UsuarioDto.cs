namespace AppCliente.Models.Usuario
{
	public record UsuarioDto(
							  string Nombre,
							  string Apellido,
							  string Email,
							  string Password
							  )
	{
	}
}
