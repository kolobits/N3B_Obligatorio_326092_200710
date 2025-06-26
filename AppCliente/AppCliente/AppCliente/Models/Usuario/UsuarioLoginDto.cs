using System.ComponentModel.DataAnnotations;

namespace AppCliente.Models.Usuario
{
	public record UsuarioLoginDto
	//(
	//string Email,
	//string Password)
	{
		[Required(ErrorMessage = "El Email del usuario es requerido")]
		[EmailAddress(ErrorMessage = "Formato de Email es inválido")]
		public string Email { get; set; }

		[Required(ErrorMessage = "La contraseña del usuario es requerida")]
		public string Password { get; set; }
	}


}
