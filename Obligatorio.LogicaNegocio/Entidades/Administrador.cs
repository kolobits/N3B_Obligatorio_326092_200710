using Obligatorio.LogicaNegocio.Vo.Usuario;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class Administrador : Empleado
	{
		public Administrador(int id, NombreCompleto nombreCompleto, Email email, Password password) : base(id, nombreCompleto, email, password)
		{
		}

		protected Administrador() { }
	}
}
