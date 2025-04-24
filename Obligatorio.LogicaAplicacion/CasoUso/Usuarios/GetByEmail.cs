using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;


namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
    public class GetByEmail : IGetByEmail<UsuarioListadoDto>
    {
        private IRepositorioUsuario _repo;

        public GetByEmail(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public UsuarioListadoDto Execute(string valor)
        {
            return UsuarioMapper.ToDto(_repo.GetByEmail(valor));
        }
    }
}
