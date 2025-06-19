using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios
{
	public interface IRepositorioEnvio :
		IRepositorioAdd<Envio>,
		IRepositorioGetAll<Envio>,
		IRepositorioUpdate<Envio>,
		IRepositorioGetById<Envio>,
		IRepositorioGetByTracking<Envio>,
		IRepositorioGetAllEnviosCliente<Envio>
	{

	}
}
