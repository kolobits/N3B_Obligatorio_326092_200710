using Obligatorio.LogicaNegocio.Vo.Agencia;
using Obligatorio.LogicaNegocio.Vo.Envio;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class EnvioUrgente : Envio
	{
		public DireccionPostal DireccionPostal { get; set; }
		public bool EsEficiente { get; set; }
		public EnvioUrgente(int id, Tracking tracking, int empleadoId, int clienteId, Peso peso, Estado estado, List<Seguimiento> seguimientos, DireccionPostal direccionPostal, bool EsEficiente) : base(id, tracking, empleadoId, clienteId, peso, estado, seguimientos)
		{
		}
		protected EnvioUrgente()
		{
		}
	}
}
