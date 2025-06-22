namespace AppCliente.Models.Envio
{
	public record EnvioListadoDto(
		int Id,
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
