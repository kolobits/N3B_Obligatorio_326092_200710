using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAplicacion.Mapper
{
	class AuditoriaMapper
	{
		public static Auditoria FromDto(AuditoriaDto auditoriaDto)
		{
			return new Auditoria(0,
								 auditoriaDto.UsuarioId,
								 auditoriaDto.Fecha,
								 auditoriaDto.Accion);
		}
	}
}
