namespace Obligatorio.LogicaNegocio.Vo.Envio
{
	public class Peso
	{
		public double Value { get; }

		public Peso(double value)
		{
			Value = value;
			Validar();
		}

		protected Peso() { }
		private void Validar()
		{

		}

	}
}
