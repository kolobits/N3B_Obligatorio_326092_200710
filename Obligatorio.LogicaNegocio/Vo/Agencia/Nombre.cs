
using Obligatorio.LogicaNegocio.Excepciones.Agencia;

namespace Obligatorio.LogicaNegocio.Vo.Agencia
{
	public record Nombre
	{
		public string Value { get; }

		protected Nombre() { } // Constructor protegido para EF Core

		public Nombre(string value)
		{
			Value = value;
			Validar();
		}

		private void Validar()
		{
			if (string.IsNullOrEmpty(Value))
				throw new NombreException("El nombre de la agencia no puede estar vacío");
		}
	}
}
