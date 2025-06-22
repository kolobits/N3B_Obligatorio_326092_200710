namespace AppCliente.Models.Envio
{
	public record EnvioDto(
			int Tracking,
			string Empleado,
			string Cliente,
			string Estado,
			double Peso,
			string Tipo,
			string UltimoComentario,
			DateTime? FechaCreacion,
			DateTime? FechaFinalizacion
						   )
	{
	}
}