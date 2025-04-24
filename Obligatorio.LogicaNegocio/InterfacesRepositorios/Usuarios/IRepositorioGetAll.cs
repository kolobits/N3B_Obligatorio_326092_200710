namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios
{
	public interface IRepositorioGetAll<T>
	{
		IEnumerable<T> GetAll();
	}
}