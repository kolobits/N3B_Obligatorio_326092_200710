using Obligatorio.LogicaNegocio.Vo.Usuario;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class Funcionario : Empleado
	{

		public Funcionario(int id, NombreCompleto nombreCompleto, Email email, Password password) : base(id, nombreCompleto, email, password)
		{
		}

		public Funcionario() { }
	}
}
