using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Excepciones.Usuario
{
    public class EmailRepetidoException : UsuarioException
    {
        public EmailRepetidoException()
        {
        }
        public EmailRepetidoException(string? message) : base(message)
        {
        }
    }
}
