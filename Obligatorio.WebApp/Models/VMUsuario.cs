using System.ComponentModel.DataAnnotations;

namespace Obligatorio.WebApp.Models
{
	public class VMUsuario
	{
		public int Id { get; set; }

		[StringLength(10, MinimumLength = 3, ErrorMessage = "Largo del nombre: entre 3 y 10 caracteres")]
       
		[Required(ErrorMessage = "El nombre del usuario es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del usuario es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Email del usuario es requerido")]
        [EmailAddress(ErrorMessage = "Formato de Email es inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña del usuario es requerida")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[+.#]).{6,}$", ErrorMessage = "La contraseña debe contener letras numeros y 1 carácter (+.#), largo minimo 6")]
		public string Password { get; set; }
	}
}
