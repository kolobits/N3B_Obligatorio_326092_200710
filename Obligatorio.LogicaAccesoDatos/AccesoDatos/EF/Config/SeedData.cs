using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo.Agencia;
using Obligatorio.LogicaNegocio.Vo.Usuario;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
	public class SeedData
	{
		private ObligatorioContext _context;

		public SeedData(ObligatorioContext context)
		{
			_context = context;
		}

		public void Run()
		{
			if (!_context.Agencias.Any()) Agencia();
			if (!_context.Usuarios.Any()) Usuario();
		}

		private void Agencia()
		{
			Agencia agencia1 = null;
			agencia1 = new Agencia(
				0,
				new Nombre("Centro"),
				new DireccionPostal("18 de Julio", 1234, 11100),
				new Ubicacion(-34.9011, -56.1645)
			);
			_context.Agencias.Add(agencia1);

			Agencia agencia2 = null;
			agencia2 = new Agencia(
				0,
				new Nombre("Pocitos"),
				new DireccionPostal("Ellauri", 456, 11300),
				new Ubicacion(-34.9075, -56.1486)
			);
			_context.Agencias.Add(agencia2);

			_context.SaveChanges();
		}

		private void Usuario()
		{
			Administrador unAdmin = null;
			unAdmin = new Administrador(0,
				new NombreCompleto("Juan", "Perez"),
				new Email("juanperez@gmail.com"),
				new Password("Hola456+")
				);
			_context.Usuarios.Add(unAdmin);

			Funcionario unFuncionario = null;
			unFuncionario = new Funcionario(0,
				new NombreCompleto("Maria", "Gomez"),
				new Email("mariagomez@gmail.com"),
				new Password("Hola456#")
				);
			_context.Usuarios.Add(unFuncionario);


			Cliente unCliente = null;
			unCliente = new Cliente(0,
				new NombreCompleto("Carlos", "Rodriguez"),
				new Email("carlosrodri@gmail.com"),
				new Password("Hola678+")
				);
			_context.Usuarios.Add(unCliente);

			_context.SaveChanges();
		}
	}
}