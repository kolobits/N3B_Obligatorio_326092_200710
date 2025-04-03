using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Excepciones.Usuario
{
    public class EmailException : UsuarioException
    {
        public EmailException()
        {
        }

        public EmailException(string? message) : base(message)
        {
        }
    }
}
