using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;

namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario
{
	public interface ILoginWebApi<T>
	{
		UsuarioLogueadoDto Execute(T obj);
	}


}
