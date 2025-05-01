using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo.Envio;

namespace Obligatorio.LogicaAplicacion.Mapper
{
	public static class EnvioMapper
	{
		public static EnvioComun FromDtoEnvioComun(
			EnvioDto dto,
			int empleadoId,
			int clienteId
			)
		{
			return new EnvioComun(
				0,
				new Tracking(new Random().Next(100000, 999999)),
				empleadoId,
				clienteId,
				new Peso(dto.Peso),
				Estado.En_Proceso,
				new List<Seguimiento>(),
				dto.AgenciaId
			);
		}

		public static EnvioListadoDto ToDto(Envio envio)
		{
			string tipo = envio is EnvioComun ? "Común" : "Urgente";

			return new EnvioListadoDto(
				envio.Id,
				envio.Tracking.Value,
				envio.Cliente.Email.Value,
				envio.Empleado.NombreCompleto.Nombre,
				envio.Estado.ToString(),
				envio.Peso.Value,
				tipo
			);
		}

		public static IEnumerable<EnvioListadoDto> ToListDto(IEnumerable<Envio> envios)
		{
			List<EnvioListadoDto> lista = new();

			foreach (var envio in envios)
			{
				lista.Add(ToDto(envio));
			}
			return lista;
		}
	}
}

