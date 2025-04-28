using Obligatorio.LogicaNegocio.Excepciones.Usuario;

namespace Obligatorio.LogicaNegocio.Vo.Usuario
{
    public class Password
    {
        public string Value { get; }

		protected Password() { } // Constructor protegido para EF Core
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

        public override bool Equals(object obj)
        {
            if (obj is Password other)
                return Value == other.Value;

            return false;
        }
    }
}
