using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;


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
