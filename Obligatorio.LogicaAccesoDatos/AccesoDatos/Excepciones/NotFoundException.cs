using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Infraestructura.AccesoDatos.Excepciones
{
    public class NotFoundException : InfraestructuraException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public override int statusCode()
        {
            return 404;
        }
    }
}
