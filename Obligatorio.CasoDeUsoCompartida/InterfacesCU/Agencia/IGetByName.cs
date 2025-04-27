namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Agencia
{
	public interface IGetByName<T>
	{
		T Execute(string nombre);
	}
}
