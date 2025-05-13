namespace Obligatorio.LogicaNegocio.Excepciones.Envio
{
	public class TrackingException : EnvioException
	{
		public TrackingException()
		{
		}

		public TrackingException(string? message) : base(message)
		{
		}
	}
}
