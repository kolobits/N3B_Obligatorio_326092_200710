using Obligatorio.LogicaNegocio.Excepciones.Envio;

namespace Obligatorio.LogicaNegocio.Vo.Envio
{
	public class Tracking
	{
		public int Value { get; }

		protected Tracking() { } // Constructor protegido para EF Core


		public Tracking(int value)
		{
			Value = value;
			Validar();
		}

		private void Validar()
		{
			if (Value <= 0)
				throw new TrackingException("El tracking debe ser mayor a cero.");

			if (Value.ToString().Length < 6)
				throw new TrackingException("El tracking debe tener al menos 6 dígitos.");

		}
	}
}
