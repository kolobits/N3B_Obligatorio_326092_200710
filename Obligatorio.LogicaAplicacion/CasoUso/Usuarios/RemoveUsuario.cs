using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
