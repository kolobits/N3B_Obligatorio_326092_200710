using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario :
        IRepositorioAdd<Usuario>,
        IRepositorioGetAll<Usuario>,
        IRepositorioRemove,
        IRepositorioGetById<Usuario>,
        IRepositorioUpdate<Usuario>,
        IRepositorioGetByEmail<Usuario>
        
    {
       
    }
}
