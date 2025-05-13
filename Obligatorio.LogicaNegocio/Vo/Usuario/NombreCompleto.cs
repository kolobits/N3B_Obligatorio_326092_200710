using Obligatorio.LogicaNegocio.Excepciones.Usuario;

namespace Obligatorio.LogicaNegocio.Vo.Usuario
{
	public record NombreCompleto
	{
		public string Nombre { get; }
		public string Apellido { get; }

		protected NombreCompleto() { } // Constructor protegido para EF Core
		public NombreCompleto(string nombre, string apellido)
		{
			Nombre = nombre;
			Apellido = apellido;
			Validar();
		}

		public void Validar()
		{
			if (string.IsNullOrEmpty(Nombre))
				throw new NombreException("Nombre inválido");

			if (string.IsNullOrEmpty(Apellido))
				throw new NombreException("Apellido inválido");
		}

	}
}
