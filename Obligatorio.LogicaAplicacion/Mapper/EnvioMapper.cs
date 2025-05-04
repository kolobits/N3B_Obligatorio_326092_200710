using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo.Agencia;
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

		public static EnvioUrgente FromDtoEnvioUrgente(
		EnvioDto dto,
		int empleadoId,
		int clienteId
		)
		{
			return new EnvioUrgente(
				0,
				new Tracking(new Random().Next(100000, 999999)),
				empleadoId,
				clienteId,
				new Peso(dto.Peso),
				Estado.En_Proceso,
				new List<Seguimiento>(),
				new DireccionPostal(dto.Calle,
									dto.Numero,
									dto.CodigoPostal),
				false
			);
		}


		public static EnvioListadoDto ToDto(Envio envio)
		{
			return new EnvioListadoDto(
				envio.Id,
				envio.Tracking.Value,
				envio.Cliente.NombreCompleto.Nombre,
				envio.Empleado.NombreCompleto.Nombre,
				envio.Estado.ToString(),
				envio.Peso.Value,
				envio.Discriminator
			);
		}

		public static IEnumerable<EnvioListadoDto> ToListDto(IEnumerable<Envio> envios)
		{
			List<EnvioListadoDto> enviosDto = new List<EnvioListadoDto>();

			foreach (var item in envios)
			{
				enviosDto.Add(new EnvioListadoDto(item.Id,
												  item.Tracking.Value,
												  item.Cliente.NombreCompleto.Nombre,
												  item.Empleado.NombreCompleto.Nombre,
												  item.Estado.ToString(),
												  item.Peso.Value,
												  item.Discriminator));
			}
			return enviosDto;
		}

		public static Envio ForUpdate(Envio envio)
		{
			envio.Estado = Estado.Finalizado;
			return envio;
		}
		

    }
}

