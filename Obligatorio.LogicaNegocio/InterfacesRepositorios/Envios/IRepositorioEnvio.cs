using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios
{
	public interface IRepositorioEnvio :
		IRepositorioAdd<Envio>,
		IRepositorioGetAll<Envio>,
		IRepositorioUpdate<Envio>,
		IRepositorioGetById<Envio>,
		IRepositorioGetByTracking<Envio>

	{

	}
}
