namespace Obligatorio.CasoDeUsoCompartida.DTOs.Agencia
{
	public record AgenciaListadoDto(
						int Id,
						string Nombre,
						string Calle,
						int Numero,
						int CodigoPostal,
						double Latitud,
						double Longitud
					   )
	{
	}
}
