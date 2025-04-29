using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo.Agencia;
using Obligatorio.LogicaNegocio.Vo.Envio;

namespace Obligatorio.LogicaAplicacion.Mapper
{
	public static class EnvioMapper
	{
		public static Envio FromDto(
			EnvioDto dto,
			Empleado empleado,
			Cliente cliente,
			Agencia? agencia = null,
			DireccionPostal? direccionPostal = null)
		{
			Tracking tracking = new Tracking(new Random().Next(100000, 999999));
			Peso peso = new Peso(dto.Peso);
			Estado estado = Estado.En_Proceso;
			List<Seguimiento> seguimientos = new();

			if (dto.Tipo.ToLower() == "comun")
			{
				if (agencia == null)
					throw new ArgumentException("La agencia es requerida para envíos comunes.");

				return new EnvioComun(0, tracking, empleado, cliente, peso, estado, seguimientos, agencia);
			}
			else if (dto.Tipo.ToLower() == "urgente")
			{
				if (direccionPostal == null)
					throw new ArgumentException("La dirección postal es requerida para envíos urgentes.");

				return new EnvioUrgente(0, tracking, empleado, cliente, peso, estado, seguimientos, direccionPostal, false);
			}
			else
			{
				throw new ArgumentException("Tipo de envío inválido.");
			}
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

