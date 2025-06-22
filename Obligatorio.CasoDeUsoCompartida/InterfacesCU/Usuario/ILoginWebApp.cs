namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario
{
	public interface ILoginWebApp<T>
	{
		T Execute(string email, string password);
	}
}
