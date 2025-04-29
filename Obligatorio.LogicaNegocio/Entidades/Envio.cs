using Obligatorio.LogicaNegocio.Vo.Envio;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public abstract class Envio
	{
		public int Id { get; set; }
		public Tracking Tracking { get; set; }
		public Empleado Empleado { get; set; }
		public Cliente Cliente { get; set; }
		public Peso Peso { get; set; }
		public Estado Estado { get; set; }
		public string? Discriminator { get; set; }
		public List<Seguimiento> Seguimientos { get; set; }

		public Envio(int id, Tracking tracking, Empleado empleado, Cliente cliente, Peso peso, Estado estado, List<Seguimiento> seguimientos)
		{
			Id = id;
			Tracking = tracking;
			Empleado = empleado;
			Cliente = cliente;
			Estado = estado;
			Peso = peso;
			Seguimientos = seguimientos;
		}
		protected Envio() { } // Constructor protegido para EF Core
	}
}
