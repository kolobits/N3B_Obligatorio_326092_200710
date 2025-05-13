namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario
{
	public interface IGetAll<T>
	{
		IEnumerable<T> Execute();
	}
}
