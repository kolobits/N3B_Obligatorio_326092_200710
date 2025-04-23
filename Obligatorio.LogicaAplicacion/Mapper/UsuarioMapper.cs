using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
	public static class UsuarioMapper
	{
		public static Usuario FromDto(UsuarioDto usuarioDto)
		{
			return new Usuario(0,
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
			List<UsuarioListadoDto> usuariosDto = new List<UsuarioListadoDto>();

			foreach (var item in usuarios)
			{
				usuariosDto.Add(new UsuarioListadoDto(item.Id, item.NombreCompleto.Nombre, item.NombreCompleto.Apellido, item.Email.Value));
			}
			return usuariosDto;
		}



	}

}

