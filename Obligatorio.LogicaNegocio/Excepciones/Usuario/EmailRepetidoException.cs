namespace Obligatorio.LogicaNegocio.Excepciones.Usuario
{
	public class EmailRepetidoException : UsuarioException
	{
		public EmailRepetidoException()
		{
		}
		public EmailRepetidoException(string? message) : base(message)
		{
		}
	}
}
