namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario
{
	public interface IUpdate<T>
	{
		void Execute(int id, T obj);
	}
}
