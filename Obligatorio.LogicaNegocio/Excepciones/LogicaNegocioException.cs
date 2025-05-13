namespace Obligatorio.LogicaNegocio.Excepciones
{
	public class LogicaNegocioExpception : Exception
	{
		public LogicaNegocioExpception()
		{
		}

		public LogicaNegocioExpception(string? message) : base(message)
		{
		}
	}
}
