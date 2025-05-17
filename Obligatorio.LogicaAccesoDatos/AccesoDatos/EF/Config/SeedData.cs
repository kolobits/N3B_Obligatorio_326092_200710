using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo.Agencia;
using Obligatorio.LogicaNegocio.Vo.Envio;
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
			Agencia agencia1 = new Agencia(0,
			new Nombre("Sucursal Montevideo - Tres Cruces"),
			new DireccionPostal("Bv. Gral. Artigas", 1825, 11100),
			new Ubicacion(-34.9011, -56.1645));
			_context.Agencias.Add(agencia1);

			Agencia agencia2 = new Agencia(0,
				new Nombre("Sucursal Canelones - Pando"),
				new DireccionPostal("Gral. Artigas", 1000, 91000),
				new Ubicacion(-34.7174, -55.9586));
			_context.Agencias.Add(agencia2);

			Agencia agencia3 = new Agencia(0,
				new Nombre("Sucursal Maldonado - Centro"),
				new DireccionPostal("Av. Aiguá", 786, 20000),
				new Ubicacion(-34.9064, -54.9587));
			_context.Agencias.Add(agencia3);

			Agencia agencia4 = new Agencia(0,
				new Nombre("Sucursal Rocha - Ciudad de Rocha"),
				new DireccionPostal("18 de Julio", 1234, 27000),
				new Ubicacion(-34.4833, -54.3333));
			_context.Agencias.Add(agencia4);

			Agencia agencia5 = new Agencia(0,
				new Nombre("Sucursal Rivera - Centro"),
				new DireccionPostal("Sarandí", 890, 40000),
				new Ubicacion(-30.9053, -55.5500));
			_context.Agencias.Add(agencia5);

			Agencia agencia6 = new Agencia(0,
				new Nombre("Sucursal Salto - Terminal"),
				new DireccionPostal("Uruguay", 1450, 50000),
				new Ubicacion(-31.3833, -57.9667));
			_context.Agencias.Add(agencia6);

			Agencia agencia7 = new Agencia(0,
				new Nombre("Sucursal Paysandú - Centro"),
				new DireccionPostal("Florida", 1122, 60000),
				new Ubicacion(-32.3214, -58.0756));
			_context.Agencias.Add(agencia7);

			Agencia agencia8 = new Agencia(0,
				new Nombre("Sucursal Tacuarembó - Centro"),
				new DireccionPostal("25 de Mayo", 850, 45000),
				new Ubicacion(-31.7333, -55.9833));
			_context.Agencias.Add(agencia8);

			Agencia agencia9 = new Agencia(0,
				new Nombre("Sucursal Colonia - Colonia del Sacramento"),
				new DireccionPostal("Av. General Flores", 500, 70000),
				new Ubicacion(-34.4717, -57.8447));
			_context.Agencias.Add(agencia9);

			Agencia agencia10 = new Agencia(0,
				new Nombre("Sucursal Durazno - Centro"),
				new DireccionPostal("Manuel Oribe", 1340, 97000),
				new Ubicacion(-33.3833, -56.5167));
			_context.Agencias.Add(agencia10);

			_context.SaveChanges();
		}

		private void Usuario()
		{
			Administrador Admin1 = null;
			Admin1 = new Administrador(0,
				new NombreCompleto("Juan", "Perez"),
				new Email("juanperez@gmail.com"),
				new Password("Hola456+")
				);
			_context.Usuarios.Add(Admin1);

			Administrador Admin2 = null;
			Admin2 = new Administrador(0,
				new NombreCompleto("Luis", "Dentone"),
				new Email("administrador@gmial.com"),
				new Password("Gerente2025.")
				);
			_context.Usuarios.Add(Admin2);

			Funcionario unFuncionario = null;
			unFuncionario = new Funcionario(0,
				new NombreCompleto("Maria", "Gomez"),
				new Email("mariagomez@gmail.com"),
				new Password("Hola456#")
				);
			_context.Usuarios.Add(unFuncionario);


			Cliente cliente1 = new Cliente(0,
			new NombreCompleto("Ana", "González"),
			new Email("ana.gonzalez@gmail.com"),
			new Password("Ana2024!"));
			_context.Usuarios.Add(cliente1);

			Cliente cliente2 = new Cliente(0,
				new NombreCompleto("Luis", "Pereyra"),
				new Email("luis.pereyra@hotmail.com"),
				new Password("Luis#123"));
			_context.Usuarios.Add(cliente2);

			Cliente cliente3 = new Cliente(0,
				new NombreCompleto("María", "Fernández"),
				new Email("maria.fernandez@yahoo.com"),
				new Password("M4riaPass$"));
			_context.Usuarios.Add(cliente3);

			Cliente cliente4 = new Cliente(0,
				new NombreCompleto("Santiago", "Silva"),
				new Email("santi.silva@gmail.com"),
				new Password("S4nti_2025"));
			_context.Usuarios.Add(cliente4);

			_context.SaveChanges();
		}
	}
}