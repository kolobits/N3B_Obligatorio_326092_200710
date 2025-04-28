using System.ComponentModel.DataAnnotations;

namespace Obligatorio.WebApp.Models
{
	public class VMUsuario
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "El nombre del usuario es requerido")]
		[StringLength(10, MinimumLength = 3, ErrorMessage = "Largo del nombre: entre 3 y 10 caracteres")]

		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[+.#]).{6,}$", ErrorMessage = "La contraseña debe contener letras numeros y 1 carácter (+.#), largo minimo 6")]
		public string Password { get; set; }
	}
}
