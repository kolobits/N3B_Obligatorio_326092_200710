using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class Seguimiento : IEntity
	{
		public int Id { get; set; }
		public string Comentario { get; set; }
		public DateTime Fecha { get; set; }
		public Empleado Empleado { get; set; }
		public int EmpleadoId { get; set; }
		public int EnvioId { get; set; }
		public Seguimiento(int id, string comentario, DateTime fecha, int empleadoId, int envioId)
		{
			Id = id;
			Comentario = comentario;
			Fecha = fecha;
			EmpleadoId = empleadoId;
			EnvioId = envioId;
		}

		protected Seguimiento() { }
	}
}
