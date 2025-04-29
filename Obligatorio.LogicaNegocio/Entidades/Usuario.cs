using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.Vo.Usuario;
namespace Obligatorio.LogicaNegocio.Entidades
{
	public abstract class Usuario : IEntity, IEquatable<Usuario>
	{
		public int Id { get; set; }
		public NombreCompleto NombreCompleto { get; set; }
		public Email Email { get; set; }
		public Password Password { get; set; }
		public string? Discriminator { get; set; }

		protected Usuario() { } // Constructor protegido para EF Core

		public Usuario(int id, NombreCompleto nombreCompleto, Email email, Password password)
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

		public void Update(Usuario obj)
		{
			NombreCompleto = obj.NombreCompleto;
			Email = obj.Email;
			Validar();
		}

		public void Login(Usuario obj)
		{
			Email = obj.Email;
			Password = obj.Password;
			Validar();
		}
	}
}
