

using Obligatorio.LogicaNegocio.Excepciones.Usuario;

namespace Obligatorio.LogicaNegocio.Vo
{
    public class Email
    {
        public string Value { get; }

        public Email(string value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
                throw new EmailException("Email inválido");
        }
    }
}
