namespace Obligatorio.CasoDeUsoCompartida.DTOs.Seguimientos
{
	public record SeguimientoDto(
								string Comentario,
								DateTime Fecha,
                                int EnvioId
                                )
	{
	}
}

