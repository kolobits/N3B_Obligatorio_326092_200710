namespace Obligatorio.CasoDeUsoCompartida.DTOs.Envios
{
	public record EnvioDto(
						   string Tipo,
						   string Email,
						   double Peso,
						   string Agencia,
						   string Calle,
						   int Numero,
						   int CodigoPostal
						   )
	{
	}
}

