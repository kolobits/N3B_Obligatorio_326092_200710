namespace Obligatorio.LogicaNegocio.Excepciones.Envio
{
	public class EnvioException : LogicaNegocioExpception
	{
		public EnvioException()
		{
		}
		public EnvioException(string? message) : base(message)
		{
		}
	}
}