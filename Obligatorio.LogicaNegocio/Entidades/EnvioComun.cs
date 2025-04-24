namespace Obligatorio.LogicaNegocio.Entidades
{
	public class EnvioComun : Envio
	{
		public EnvioComun(int id, Tracking tracking, Empleado empleado, Cliente cliente, Peso peso, Estado estado, List<Seguimiento> seguimientos) : base(id, tracking, empleado, cliente, peso, estado, seguimientos)
		{
		}
		public EnvioComun()
		{
		}
	}
    {
    }
}
