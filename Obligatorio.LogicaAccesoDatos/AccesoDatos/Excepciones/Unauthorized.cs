using System.Runtime.Serialization;

namespace Obligatorio.Infraestructura.AccesoDatos.Excepciones
{
	public class Unauthorized : InfraestructuraException
	{
		public Unauthorized()
		{
		}

		public Unauthorized(string? message) : base(message)
		{
		}

		protected Unauthorized(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public override int StatusCode()
		{
			return 401;
		}
	}
}
