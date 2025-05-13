namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio
{
	public interface IGetByTracking<T>
	{
		T Execute(int id);
	}
}
