
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;

namespace Obligatorio.LogicaNegocio.Vo
{
    public class Email
    {
        public string Value { get; }

		protected Email() { } // Constructor protegido para EF Core
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

      

        public override bool Equals(object obj)
        {
            if (obj is Email other)
                return Value == other.Value;

            return false;
        }
    }
}
