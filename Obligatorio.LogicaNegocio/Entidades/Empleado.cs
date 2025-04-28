using Obligatorio.LogicaNegocio.Vo.Usuario;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class Empleado : Usuario
	{
		public Empleado(int id, NombreCompleto nombreCompleto, Email email, Password password) : base(id, nombreCompleto, email, password)
		{
		}
		protected Empleado() { }
	}
}
