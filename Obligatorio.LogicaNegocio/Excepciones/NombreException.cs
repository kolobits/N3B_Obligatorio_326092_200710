using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class NombreException : LogicaNegocioExpception
    {
        public NombreException() { }

        public NombreException(string? message) : base(message)
        {
        }


    }
}
