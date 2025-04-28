namespace Obligatorio.LogicaNegocio.Vo.Agencia
{
	public record Nombre
	{
		public string Value { get; }

		public Nombre(string value)
		{
			Value = value;
		}

		protected Nombre() { } // Constructor protegido para EF Core
	}
}
