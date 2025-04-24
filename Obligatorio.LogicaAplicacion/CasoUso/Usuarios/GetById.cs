using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
    public class GetById : IGetById<UsuarioListadoDto>
    {
        private IRepositorioUsuario _repo;

        public GetById(IRepositorioUsuario repo)
        {
            _repo = repo;
        }


        public UsuarioListadoDto Execute(int id)
        {
            return UsuarioMapper.ToDto(_repo.GetById(id));
        }
    }
}
