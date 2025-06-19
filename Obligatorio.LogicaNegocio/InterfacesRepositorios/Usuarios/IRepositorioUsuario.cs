using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios
{
	public interface IRepositorioUsuario :
		IRepositorioAdd<Usuario>,
		IRepositorioGetAll<Usuario>,
		IRepositorioRemove,
		IRepositorioGetById<Usuario>,
		IRepositorioUpdate<Usuario>,
		IRepositorioGetByEmail<Usuario>
	//IRepositorioUpdatePassword<Usuario>

	{

	}
}
