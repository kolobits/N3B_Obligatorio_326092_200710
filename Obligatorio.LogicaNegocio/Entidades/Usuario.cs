using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.Vo;
namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Usuario : IEntity, IEquatable<Usuario>
	{
        public int Id { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public Email Email { get;set; }
        public Password Password { get; set; }

        public Usuario (int id, NombreCompleto nombreCompleto, Email email, Password password)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Email = email;
            Password = password;
            Validar();

        }

 

        public void Validar() 
        {
        }
       

        public bool Equals(Usuario? other)
        {
            return other != null && Email.Equals(other.Email);
        }
    }
}
