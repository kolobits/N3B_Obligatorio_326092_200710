namespace Obligatorio.CasoDeUsoCompartida.DTOs.Seguimientos
{
	public record SeguimientoListadoDto(
										int Id,
										string Comentario,
										DateTime Fecha,
										int EmpleadoId)
	{
	}
}
