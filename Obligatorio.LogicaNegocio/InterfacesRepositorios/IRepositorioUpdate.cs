namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
	public interface IRepositorioUpdate<T>
	{
		void Update(int id, T obj);
	}
}
