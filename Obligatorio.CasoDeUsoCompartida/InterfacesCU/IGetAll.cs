namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU
{
	public interface IGetAll<T>
	{
		IEnumerable<T> Execute();
	}
}
