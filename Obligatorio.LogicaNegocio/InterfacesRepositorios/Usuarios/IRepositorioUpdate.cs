namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios
{
	public interface IRepositorioUpdate<T>
	{
		void Update(int id, T obj);
	}
}
