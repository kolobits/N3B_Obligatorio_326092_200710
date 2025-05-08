namespace Obligatorio.LogicaNegocio.Entidades
{
	public class Seguimiento
	{
		public int Id { get; set; }
		public string Comentario { get; set; }
		public DateTime Fecha { get; set; }
		public Empleado Empleado { get; set; }
		public int EmpleadoId { get; set; }
		public Seguimiento(int id, string comentario, DateTime fecha, int EmpleadoId)
		{
			Id = id;
			Comentario = comentario;
			Fecha = fecha;
			EmpleadoId = EmpleadoId;
		}

		protected Seguimiento() { }
	}
}
