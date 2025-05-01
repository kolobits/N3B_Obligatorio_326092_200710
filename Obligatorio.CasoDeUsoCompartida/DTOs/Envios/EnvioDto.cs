namespace Obligatorio.CasoDeUsoCompartida.DTOs.Envios
{
	public record EnvioDto(
						   string Tipo,
						   string Email,
						   double Peso,
						   int? AgenciaId,
						   string? Calle,
						   int? Numero,
						   int? CodigoPostal
						   )
	{
	}
}