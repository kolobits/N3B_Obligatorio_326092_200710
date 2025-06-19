namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio
{
	public interface IGetAllEnviosCliente<T>
	{
		IEnumerable<T> Execute(int idCliente);
	}
}
