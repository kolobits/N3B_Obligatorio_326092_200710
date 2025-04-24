using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class EnvioComun : Envio
	{
		public Agencia agenciaRetiro { get; set; }

		public EnvioComun(int id, Tracking tracking, Empleado empleado, Cliente cliente, Peso peso, Estado estado, List<Seguimiento> seguimientos, Agencia agenciaRetiro) : base(id, tracking, empleado, cliente, peso, estado, seguimientos)
		{
		}
		protected EnvioComun()
		{
		}
	}

}
