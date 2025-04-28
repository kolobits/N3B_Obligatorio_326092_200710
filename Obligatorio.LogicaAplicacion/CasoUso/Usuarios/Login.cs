using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using Obligatorio.LogicaNegocio.Vo.Usuario;


namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
	public class Login : ILogin<Usuario>
	{
		private readonly IRepositorioUsuario _repo;

		public Login(IRepositorioUsuario repo)
		{
			_repo = repo;
		}

		public Usuario Execute(string email, string password)
		{
			var usuario = _repo.GetByEmail(email);
			if (usuario == null || !usuario.Password.Equals(new Password(password)))
			{
				throw new Exception("Email o contraseña incorrectos.");
			}
			return usuario;
		}

	}
}

