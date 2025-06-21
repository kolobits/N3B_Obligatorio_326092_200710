using Obligatorio.LogicaNegocio.Vo.Envio;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class EnvioComun : Envio
	{
		public Agencia AgenciaRetiro { get; set; }
		public int? AgenciaRetiroId { get; set; }

		public EnvioComun(int id, Tracking tracking, int empleadoId, int clienteId, Peso peso, Estado estado, List<Seguimiento> seguimientos, DateTime? fechaFinalizacion, DateTime? fechaCreacion, int? agenciaId) : base(id, tracking, empleadoId, clienteId, peso, estado, seguimientos, fechaFinalizacion, fechaCreacion)
		{
			AgenciaRetiroId = agenciaId;
		}
		protected EnvioComun()
		{
		}
	}

}
