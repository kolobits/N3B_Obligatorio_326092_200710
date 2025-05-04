namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios
{
	public interface IRepositorioGetById<T>
	{
		T GetById(int id);
	}
}
