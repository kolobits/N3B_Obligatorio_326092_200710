using System.ComponentModel.DataAnnotations;

namespace Obligatorio.WebApp.Models
{
	public class VMEnvio
	{
		public int Id { get; set; }
		public string Tipo { get; set; }

        [Required(ErrorMessage = "El email del cliente es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El peso es requerido")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "La agencia es requerida")]
        public string Agencia { get; set; }

        [Required(ErrorMessage = "La calle es requerida")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El número es requerido")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "El codigo postal es requerido")]
        public int CodigoPostal { get; set; }
	}
}

