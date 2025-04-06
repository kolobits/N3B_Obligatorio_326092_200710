using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public static class UsuarioMapper
    {
        public static Usuario FromDto(UsuarioDto usuarioDto)
        {
            return new Usuario(usuarioDto.Id,
                               new Nombre(usuarioDto.Nombre),
                               usuarioDto.Apellido,
                               new Email( usuarioDto.Email),
                               new Password(usuarioDto.Password)
                                      ); 
        }

        public static UsuarioListadoDto ToDto(Usuario usuario)
        {
            return new UsuarioListadoDto(usuario.Id, usuario.Nombre.Value, usuario.Email.Value);
        }

        public static IEnumerable<UsuarioListadoDto> ToListDto(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioListadoDto> usuariosDto = new List<UsuarioListadoDto>();

            foreach (var item in usuarios)
            {
                usuariosDto.Add(new UsuarioListadoDto(item.Id, item.Nombre.Value, item.Email.Value));
            }
            return usuariosDto;
        }
    }
}
