using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using Obligatorio.LogicaNegocio.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
    public class UpdateUsuario : IUpdate<UsuarioDto>
    {
        private IRepositorioUsuario _repo;

        public UpdateUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Execute(int id, UsuarioDto obj)
        {
            _repo.Update(id, Mapper.UsuarioMapper.ForUpdate(_repo.GetById(id), obj));
        }
    }


}
