namespace Obligatorio.LogicaNegocio.Excepciones.Usuario
{
	public class UsuarioException : LogicaNegocioExpception
	{
		public UsuarioException()
		{
		}

		public UsuarioException(string? message) : base(message)
		{
		}
	}
}
