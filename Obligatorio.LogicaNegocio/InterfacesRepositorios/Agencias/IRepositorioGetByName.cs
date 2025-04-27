namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias
{
	public interface IRepositorioGetByName<T>
	{
		T GetByName(string name);
	}
}
