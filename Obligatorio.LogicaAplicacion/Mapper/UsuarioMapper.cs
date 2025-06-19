using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo.Usuario;

namespace Obligatorio.LogicaAplicacion.Mapper
{
	public static class UsuarioMapper
	{
		public static Usuario FromDto(UsuarioDto usuarioDto)
		{
			return new Empleado(0,
							   new NombreCompleto(usuarioDto.Nombre, usuarioDto.Apellido),
							   new Email(usuarioDto.Email),
							   new Password(usuarioDto.Password)
									  );
		}

		public static Usuario ForUpdate(Usuario usuario, UsuarioDto usuarioDto)
		{
			usuario.NombreCompleto = new NombreCompleto(usuarioDto.Nombre, usuarioDto.Apellido);
			usuario.Email = new Email(usuarioDto.Email);

			if (!string.IsNullOrWhiteSpace(usuarioDto.Password))
			{
				usuario.Password = new Password(usuarioDto.Password);
			}
			return usuario;
		}


		public static UsuarioListadoDto ToDto(Usuario usuario)
		{
			return new UsuarioListadoDto(usuario.Id, usuario.NombreCompleto.Nombre, usuario.NombreCompleto.Apellido, usuario.Email.Value);
		}

		public static IEnumerable<UsuarioListadoDto> ToListDto(IEnumerable<Usuario> usuarios)
		{
			return usuarios.Select(item =>
				new UsuarioListadoDto(item.Id, item.NombreCompleto.Nombre, item.NombreCompleto.Apellido, item.Email.Value)
			);
		}

		public static UsuarioDto ToLoginDto(Usuario usuario)
		{
			return new UsuarioDto(
				usuario.Email.Value,
				usuario.Password.Value,
				usuario.NombreCompleto.Nombre,
				usuario.NombreCompleto.Apellido
			);
		}

		public static Usuario ForUpdatePassword(Usuario usuario, UsuarioDtoUpdate usuarioDtoUpdate)
		{
			usuario.Password = new Password(usuarioDtoUpdate.PasswordNueva);
			return usuario;
		}

	}

}

