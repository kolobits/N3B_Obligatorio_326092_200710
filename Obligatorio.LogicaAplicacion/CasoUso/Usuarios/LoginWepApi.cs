using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using Obligatorio.LogicaNegocio.Vo.Usuario;

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
			if (usuario == null)
				throw new NotFoundException("Usuario no encontrado.");

			var passwordVO = new Password(usuario.Password.Value);

<<<<<<< FinRF1.0
			if (!usuario.Password.Equals(new Password(obj.Password)))
				throw new BadRequestException("Contraseña incorrecta.");

			if (usuario is not Cliente)
				throw new BadRequestException("Solo los clientes pueden iniciar sesión.");
=======
			//if (!passwordVO.Equals(obj.Password))
			//{
			//	throw new BadRequestException("Contraseña incorrecta.");
			//}
>>>>>>> main

			{

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
}

