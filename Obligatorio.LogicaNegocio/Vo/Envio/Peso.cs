using Obligatorio.LogicaNegocio.Excepciones.Envio;

namespace Obligatorio.LogicaNegocio.Vo.Envio
{
	public class Peso
	{
		public double Value { get; }
		protected Peso() { }

		public Peso(double value)
		{
			Value = value;
			Validar();
		}


		private void Validar()
		{
			if (Value <= 0)
				throw new PesoException("El peso debe ser mayor a cero.");
			if (Value > 1000)
				throw new PesoException("El peso no puede ser mayor a 1000 kg.");
		}

	}
}
