namespace Obligatorio.CasoDeUsoCompartida.DTOs.Envios
{
	public record EnvioListadoDto(
		int Id,
		int Tracking,
		string Empleado,
		string Cliente,
		string Estado,
		double Peso,
		string Tipo
		)
	{
	}
}
