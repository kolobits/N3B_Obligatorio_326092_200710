namespace Obligatorio.LogicaNegocio.Excepciones.Usuario
{
	public class PasswordException : UsuarioException
	{
		public PasswordException()
		{
		}

		public PasswordException(string? message) : base(message)
		{
		}
	}
}
