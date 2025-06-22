using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
	public class LoginWebApi : ILoginWebApi<UsuarioLoginDto>
	{
		private readonly IRepositorioUsuario _repo;
		private readonly IJwtGenerator _jwtGenerator;

		public LoginWebApi(IRepositorioUsuario repo,
							IJwtGenerator jwtGenerator)
		{
			_repo = repo;
			_jwtGenerator = jwtGenerator;
		}

		public string Execute(UsuarioLoginDto obj)
		{
			UsuarioListadoDto dto = UsuarioMapper.ToDto(_repo.GetByEmail(obj.Email));
			return _jwtGenerator.GenerateToken(dto);
		}

		//public UsuarioListadoDto Execute(string email, string password)
		//{
		//	var emailVO = new Email(email);
		//	var passwordVO = new Password(password);

		//	var usuario = _repo.GetByEmail(emailVO.Value);

		//	if (usuario == null || !usuario.Password.Equals(passwordVO))
		//	{
		//		throw new Exception("Email o contraseña incorrectos.");
		//	}

		//	return UsuarioMapper.ToDto(usuario);
		//}
	}
}
