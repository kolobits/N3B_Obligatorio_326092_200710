using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.Vo;
namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Usuario : IEntity, IEquatable<Usuario>
	{
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public string Apellido { get;set; }
        public string Email { get;set; }
        public string Password { get; set; }

        public Usuario (int id, Nombre nombre, string apellido, string email, string password)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            Validar();
		}

        public void Validar()
        {
            if (Nombre == null)
                throw new NombreException("Nombre obligatorio");
			if (string.IsNullOrEmpty(Email))
                throw new EmailException("Email inválido");
            if (string.IsNullOrEmpty(Password))
                throw new PasswordException("Password inválido");
        }

        public bool Equals(Usuario? other)
        {
            return other != null && Email.Equals(other.Email);
        }
    }
}
