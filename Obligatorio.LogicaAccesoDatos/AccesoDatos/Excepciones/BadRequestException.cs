using System.Runtime.Serialization;

namespace Obligatorio.Infraestructura.AccesoDatos.Excepciones
{
	public class BadRequestException : InfraestructuraException
	{
		public BadRequestException()
		{
		}

		public BadRequestException(string? message) : base(message)
		{
		}

		protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public override int statusCode()
		{
			return 400;
		}
	}
}
