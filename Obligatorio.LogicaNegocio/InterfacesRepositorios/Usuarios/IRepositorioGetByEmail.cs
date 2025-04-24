namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios
{
	public interface IRepositorioGetByEmail<T>
	{
		T GetByEmail(string email);
	}
}
