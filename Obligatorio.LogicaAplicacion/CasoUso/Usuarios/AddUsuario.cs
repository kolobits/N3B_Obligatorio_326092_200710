using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
    public class AddUsuario : IAddUsuario<UsuarioDto>
    {
        private IRepositorioUsuario _repo;

        public AddUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Execute(UsuarioDto usuarioDto)
        {
            _repo.Add(UsuarioMapper.FromDto(usuarioDto));
        }
    }
}
