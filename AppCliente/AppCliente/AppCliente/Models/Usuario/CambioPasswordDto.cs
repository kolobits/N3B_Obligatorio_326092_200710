using System.ComponentModel.DataAnnotations;

namespace AppCliente.Models.Usuario
{
	public class CambioPasswordDto
	{
        [Required(ErrorMessage = "La contraseña actual es obligatoria.")]
        [Display(Name = "Contraseña actual")]
        public string PasswordActual { get; set; }

        [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
        [Display(Name = "Contraseña nueva")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[+.#]).{6,}$", ErrorMessage = "La contraseña debe contener letras numeros y 1 carácter (+.#), largo minimo 6")]

        public string PasswordNueva { get; set; }
	}

}
