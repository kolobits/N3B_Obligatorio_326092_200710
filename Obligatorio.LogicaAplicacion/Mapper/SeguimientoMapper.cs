using Obligatorio.CasoDeUsoCompartida.DTOs.Seguimientos;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAplicacion.Mapper
{
	public class SeguimientoMapper
	{
		public static Seguimiento FromDto(SeguimientoDto seguimientoDto, int idEmpleado)
		{
			return new Seguimiento(0, seguimientoDto.Comentario, seguimientoDto.Fecha, idEmpleado, seguimientoDto.EnvioId);
		}
	}
}
