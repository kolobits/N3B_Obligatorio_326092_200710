using Obligatorio.LogicaNegocio.Vo.Agencia;
using Obligatorio.LogicaNegocio.Vo.Envio;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class EnvioUrgente : Envio
	{
		public DireccionPostal DireccionPostal { get; set; }
		public bool EsEficiente { get; set; }
		public EnvioUrgente(int id, Tracking tracking, int empleadoId, int clienteId, Peso peso, Estado estado, List<Seguimiento> seguimientos, DateTime? fechaFinalizacion, DireccionPostal direccionPostal, bool esEficiente) : base(id, tracking, empleadoId, clienteId, peso, estado, seguimientos, fechaFinalizacion)
		{
			DireccionPostal = direccionPostal;
			EsEficiente = esEficiente;
		}
		protected EnvioUrgente()
		{
		}
	}
}
