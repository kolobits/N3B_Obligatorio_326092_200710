using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using Obligatorio.LogicaNegocio.Vo.Usuario;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
	public class LoginWebApi : ILogin<UsuarioListadoDto>
	{
		private readonly IRepositorioUsuario _repo;

		public LoginWebApi(IRepositorioUsuario repo)
		{
			_repo = repo;
		}

		public UsuarioListadoDto Execute(string email, string password)
		{
			var emailVO = new Email(email);
			var passwordVO = new Password(password);

			var usuario = _repo.GetByEmail(emailVO.Value);

			if (usuario == null || !usuario.Password.Equals(passwordVO))
			{
				throw new Exception("Email o contraseña incorrectos.");
			}

			return UsuarioMapper.ToDto(usuario);
		}
	}
}
