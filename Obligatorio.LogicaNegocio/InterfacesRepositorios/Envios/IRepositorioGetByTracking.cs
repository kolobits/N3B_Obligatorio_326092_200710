namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios
{
	public interface IRepositorioGetByTracking<T>
	{
		T GetByTracking(int tracking);

	}
}
