using Obligatorio.LogicaNegocio.Vo;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio.WebApp.Models
{
    public class VMUsuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del usuario es requerido")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Largo del nombre: entre 3 y 10 caracteres")]
        public Nombre Nombre { get; set; }
        public string Apellido { get; set; }
        public Email Email { get; set; }
        [RegularExpression(@"^[a-zA-Z''-.'\s]{6}$", ErrorMessage = "Solo letras .-")]
        public Password Password { get; set; }
    }
}
