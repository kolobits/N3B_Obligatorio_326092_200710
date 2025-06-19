namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios
{
	public interface IRepositorioGetAllEnviosCliente<T>
	{
		IEnumerable<T> GetAllEnviosCliente(int id);
	}
}
