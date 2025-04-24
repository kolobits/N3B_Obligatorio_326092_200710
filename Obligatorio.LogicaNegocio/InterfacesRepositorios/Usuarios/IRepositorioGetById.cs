namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios
{
	public interface IRepositorioGetById<T>
	{
		T GetById(int id);
	}
}