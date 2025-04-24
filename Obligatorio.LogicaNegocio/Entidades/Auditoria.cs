namespace Obligatorio.LogicaNegocio.Entidades
{
	public class Auditoria
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public DateTime Fecha { get; set; }
		public string Accion { get; set; }

		public Auditoria(int id, int usuarioId, DateTime fecha, string accion)
		{
			Id = id;
			UsuarioId = usuarioId;
			Fecha = fecha;
			Accion = accion;
		}

		public Auditoria()
		{
		}
	}
}
