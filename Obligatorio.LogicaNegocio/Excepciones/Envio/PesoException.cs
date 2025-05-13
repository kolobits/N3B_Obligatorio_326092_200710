namespace Obligatorio.LogicaNegocio.Excepciones.Envio
{
	public class PesoException : EnvioException
	{
		public PesoException()
		{
		}
		public PesoException(string? message) : base(message)
		{
		}
	}
}
