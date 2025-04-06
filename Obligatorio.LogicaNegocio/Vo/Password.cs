using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Vo
{
    public class Password
    {
        public string Value { get; }

        public Password(string value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
                throw new PasswordException("Password inválido");
        }
    }
}
