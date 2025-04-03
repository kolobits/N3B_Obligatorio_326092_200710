using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Excepciones.Usuario
{
    public class UsuarioException : LogicaNegocioExpception
    {
        public UsuarioException()
        {
        }

        public UsuarioException(string? message) : base(message)
        {
        }
    }
}
