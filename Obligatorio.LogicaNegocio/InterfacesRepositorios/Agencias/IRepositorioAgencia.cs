using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Auditorias;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias
{
	public interface IRepositorioAgencia :
	IRepositorioAdd<Agencia>,
	IRepositorioGetByName<Agencia>
	{

	}
}
