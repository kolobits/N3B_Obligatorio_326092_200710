namespace Obligatorio.LogicaNegocio.Excepciones.Agencia
{
	public class NombreException : AgenciaException
	{
		public NombreException()
		{
		}
		public NombreException(string? message) : base(message)
		{
		}
	}
}
