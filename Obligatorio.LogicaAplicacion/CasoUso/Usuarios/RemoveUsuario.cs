using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
    public class RemoveUsuario : IRemove
    {
        private IRepositorioUsuario _repo;

        public RemoveUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }
        public void Execute(int id)
        {
            _repo.Remove(id);
        }

    }
}
