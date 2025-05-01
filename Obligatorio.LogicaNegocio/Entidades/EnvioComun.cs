using Obligatorio.LogicaNegocio.Vo.Envio;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class EnvioComun : Envio
	{
		public Agencia AgenciaRetiro { get; set; }
		public int AgenciaRetiroId { get; set; }

		public EnvioComun(int id, Tracking tracking, int empleadoId, int clienteId, Peso peso, Estado estado, List<Seguimiento> seguimientos, int agenciaId) : base(id, tracking, empleadoId, clienteId, peso, estado, seguimientos)
		{
			AgenciaRetiroId = agenciaId;
		}
		protected EnvioComun()
		{
		}
	}

}
