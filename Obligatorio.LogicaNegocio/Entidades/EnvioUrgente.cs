using Obligatorio.LogicaNegocio.Vo.Agencia;
using Obligatorio.LogicaNegocio.Vo.Envio;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class EnvioUrgente : Envio
	{
		public DireccionPostal DireccionPostal { get; set; }
		public bool EsEficiente { get; set; }
		public EnvioUrgente(int id, Tracking tracking, Empleado empleado, Cliente cliente, Peso peso, Estado estado, List<Seguimiento> seguimientos, DireccionPostal direccionPostal, bool EsEficiente) : base(id, tracking, empleado, cliente, peso, estado, seguimientos)
		{
		}
		protected EnvioUrgente()
		{
		}
	}
}
