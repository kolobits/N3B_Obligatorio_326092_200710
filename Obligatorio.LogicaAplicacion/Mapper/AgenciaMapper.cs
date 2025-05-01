using Obligatorio.CasoDeUsoCompartida.DTOs.Agencia;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAplicacion.Mapper
{
	public static class AgenciaMapper
	{

		public static AgenciaListadoDto ToDto(Agencia agencia)
		{
			return new AgenciaListadoDto(agencia.Id, agencia.Nombre.Value, agencia.DireccionPostal.Calle, agencia.DireccionPostal.Numero, agencia.DireccionPostal.CodigoPostal, agencia.Ubicacion.Latitud, agencia.Ubicacion.Longitud);
		}

		public static IEnumerable<AgenciaListadoDto> ToListDto(IEnumerable<Agencia> agencias)
		{
			List<AgenciaListadoDto> agenciasDto = new List<AgenciaListadoDto>();

			foreach (var item in agencias)
			{
				agenciasDto.Add(new AgenciaListadoDto(item.Id, item.Nombre.Value, item.DireccionPostal.Calle, item.DireccionPostal.Numero, item.DireccionPostal.CodigoPostal, item.Ubicacion.Latitud, item.Ubicacion.Longitud));
			}
			return agenciasDto;
		}


	}
}
