namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios
{
	public interface IRepositorioUpdate<T>
	{
		void Update(int id,T obj);
	}
}
