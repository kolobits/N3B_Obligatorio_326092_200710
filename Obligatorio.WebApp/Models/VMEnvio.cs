namespace Obligatorio.WebApp.Models
{
	public class VMEnvio
	{
		public int Id { get; set; }
		public string Tipo { get; set; }
		public string Email { get; set; }
		public double Peso { get; set; }
		public string Agencia { get; set; }
		public string Calle { get; set; }
		public int Numero { get; set; }
		public int CodigoPostal { get; set; }
	}
}

