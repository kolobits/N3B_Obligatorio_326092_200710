namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario
{
	public interface IGetById<T>
	{
		T Execute(int id);
	}
}
