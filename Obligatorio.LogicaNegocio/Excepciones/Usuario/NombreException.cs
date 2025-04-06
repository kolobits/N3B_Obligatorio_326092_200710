

namespace Obligatorio.LogicaNegocio.Excepciones.Usuario
{
   public class NombreException : UsuarioException
	{
		public NombreException()
		{
		}
		public NombreException(string? message) : base(message)
		{
		}
	}
}
