using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

        public override int statusCode()
        {
            return 401;
        }
    }
}
