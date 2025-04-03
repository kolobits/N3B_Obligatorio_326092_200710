using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Excepciones.Usuario
{
    public class PasswordException : UsuarioException
    {
        public PasswordException()
        {
        }

        public PasswordException(string? message) : base(message)
        {
        }
    }
}
