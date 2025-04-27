namespace Obligatorio.LogicaNegocio.Vo
{
	public class Tracking
	{
		public int Value { get; }

		public Tracking(int value)
		{
			Value = value;
			Validar();
		}

		protected Tracking() { }

		private void Validar()
		{

		}
	}
}
