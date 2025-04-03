using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
