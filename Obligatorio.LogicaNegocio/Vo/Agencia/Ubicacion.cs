
using Obligatorio.LogicaNegocio.Excepciones.Agencia;

namespace Obligatorio.LogicaNegocio.Vo.Agencia
{
	public record Ubicacion
	{
		public double Latitud { get; }
		public double Longitud { get; }
		protected Ubicacion() { } // Constructor protegido para EF Core
		public Ubicacion(double latitud, double longitud)
		{
			Latitud = latitud;
			Longitud = longitud;
			Validar();
		}

		private void Validar()
		{
			if (Latitud < -90 || Latitud > 90)
				throw new UbicacionException("La latitud debe estar entre -90 y 90 grados.");

			if (Longitud < -180 || Longitud > 180)
				throw new UbicacionException("La longitud debe estar entre -180 y 180 grados.");
		}
	}
}
