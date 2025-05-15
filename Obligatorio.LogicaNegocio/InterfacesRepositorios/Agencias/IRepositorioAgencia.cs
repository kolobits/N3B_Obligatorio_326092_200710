using Obligatorio.LogicaNegocio.Entidades;


namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias
{
	public interface IRepositorioAgencia :
	IRepositorioAdd<Agencia>,
	IRepositorioGetByName<Agencia>,
	IRepositorioGetById<Agencia>,
	IRepositorioGetAll<Agencia>
	{

	}
}
