namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario
{
	public interface IGetByEmail<T>
	{
		T Execute(string email);
	}
}
