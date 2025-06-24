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

		public LoginWebApi(IRepositorioUsuario repo, IJwtGenerator jwtGenerator)
		{
			_repo = repo;
			_jwtGenerator = jwtGenerator;
		}

		public UsuarioLogueadoDto Execute(UsuarioLoginDto obj)
		{
			var usuario = _repo.GetByEmail(obj.Email);

			var dto = UsuarioMapper.ToDto(usuario);

			string token = _jwtGenerator.GenerateToken(dto);


			return new UsuarioLogueadoDto(
				Id: dto.Id,
				Nombre: dto.Nombre,
				Email: dto.Email,
				Token: token
			);
		}
	}
}

