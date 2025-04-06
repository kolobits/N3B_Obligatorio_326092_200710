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
        public Email Email { get;set; }
        public Password Password { get; set; }

        public Usuario (int id, Nombre nombre, string apellido, Email email, Password password)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            Validar();

        }

        //Consulta : si se puede poner los metodos validar public en cada vo
        public void Validar() 
        {
            Email.Validar();
            Nombre.Validar();
            Password.Validar();
        }
       

        public bool Equals(Usuario? other)
        {
            return other != null && Email.Equals(other.Email);
        }
    }
}
