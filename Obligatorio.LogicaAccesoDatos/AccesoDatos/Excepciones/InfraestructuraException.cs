
using System.Runtime.Serialization;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio.Infraestructura.AccesoDatos.Excepciones
{
    public abstract class InfraestructuraException : Exception
    {
        string _message;
        public InfraestructuraException()
        {
        }

        public InfraestructuraException(string? message) : base(message)
        {
            _message = message;
        }

        protected InfraestructuraException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public abstract int statusCode();

        public Error Error()
        {
            return new Error(
                statusCode(),
                _message
                );

        }

    }
}

