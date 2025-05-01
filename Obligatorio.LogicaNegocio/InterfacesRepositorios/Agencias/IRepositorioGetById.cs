namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias
{
	public interface IRepositorioGetById<T>
	{
		T GetById(int id);
	}
}
