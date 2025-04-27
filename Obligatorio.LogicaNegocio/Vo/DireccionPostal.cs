namespace Obligatorio.LogicaNegocio.Vo
{
	public class DireccionPostal
	{
		public string Calle { get; }
		public int Numero { get; }
		public int CodigoPostal { get; }
		public DireccionPostal(string calle, int numero, int codigoPostal)
		{
			Calle = calle;
			Numero = numero;
			CodigoPostal = codigoPostal;

		}
		protected DireccionPostal() { } // Constructor protegido para EF Core
	}
}
