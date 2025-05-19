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
				fechaFinalizacion: null,
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
				fechaFinalizacion: null,
				new DireccionPostal(dto.Calle,
									dto.Numero,
									dto.CodigoPostal),
				false
			);
		}


		public static EnvioListadoDto ToDto(Envio envio)
		{
			var ultimoComentario = envio.Seguimientos?
				.OrderByDescending(s => s.Fecha)
				.FirstOrDefault()?.Comentario ?? "Sin comentarios";
			var nombreEmpleado = $"{envio.Empleado?.NombreCompleto?.Nombre} {envio.Empleado?.NombreCompleto?.Apellido}";
			var nombreCliente = $"{envio.Cliente?.NombreCompleto?.Nombre} {envio.Cliente?.NombreCompleto?.Apellido}";

			return new EnvioListadoDto(
				envio.Id,
				envio.Tracking.Value,
				nombreEmpleado,
				nombreCliente,
				envio.Estado.ToString(),
				envio.Peso.Value,
				envio.Discriminator,
				ultimoComentario,
				envio.FechaFinalizacion
			);
		}

		public static IEnumerable<EnvioListadoDto> ToListDto(IEnumerable<Envio> envios)
		{
			List<EnvioListadoDto> enviosDto = new List<EnvioListadoDto>();


			foreach (var item in envios)
			{
				var ultimoComentario = item.Seguimientos?
					.OrderByDescending(s => s.Fecha)
					.FirstOrDefault()?.Comentario ?? "Sin comentarios";

				enviosDto.Add(new EnvioListadoDto(item.Id,
												  item.Tracking.Value,
												  item.Empleado.NombreCompleto.Nombre,
												  item.Cliente.NombreCompleto.Nombre,
												  item.Estado.ToString(),
												  item.Peso.Value,
												  item.Discriminator,
												  ultimoComentario,
												  item.FechaFinalizacion
												  ));
			}
			return enviosDto;
		}


        public static Envio ForUpdate(Envio envio)
        {
            if (envio.Estado == Estado.En_Proceso)
            {
                envio.Estado = Estado.Finalizado;
                envio.FechaFinalizacion = DateTime.Now;

                if (envio is EnvioUrgente envioUrgente)
                {
                    
                    if (envio.Seguimientos != null && envio.Seguimientos.Any())
                    {
                        var seguimientoEnvio = envio.Seguimientos
                            .FirstOrDefault(s => s.Comentario == "El envío fue enviado");

                        if (seguimientoEnvio != null && envio.FechaFinalizacion.HasValue)
                        {
                            TimeSpan tiempoTranscurrido = envio.FechaFinalizacion.Value - seguimientoEnvio.Fecha;

                            envioUrgente.EsEficiente = tiempoTranscurrido.TotalHours < 24;
                        }
                        else
                        {
                            envioUrgente.EsEficiente = false;
                        }
                    }
                    else
                    {
                        envioUrgente.EsEficiente = false;
                    }
                }
            }

            return envio;
        }


    }
}

