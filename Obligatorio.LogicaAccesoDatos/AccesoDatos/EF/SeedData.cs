using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo.Agencia;
using Obligatorio.LogicaNegocio.Vo.Envio;
using Obligatorio.LogicaNegocio.Vo.Usuario;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
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
			if (!_context.Envios.Any()) Envio();
			if (!_context.Seguimientos.Any()) Seguimiento();

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

			Administrador Admin3 = null;
			Admin3 = new Administrador(0,
				new NombreCompleto("Andrea", "Acosta"),
				new Email("acostaandrea@gmial.com"),
				new Password("Hola123+")
				);
			_context.Usuarios.Add(Admin3);

			Funcionario Funcionario1 = null;
			Funcionario1 = new Funcionario(0,
				new NombreCompleto("Maria", "Gomez"),
				new Email("mariagomez@gmail.com"),
				new Password("Hola456#")
				);
			_context.Usuarios.Add(Funcionario1);

			Funcionario Funcionario2 = null;
			Funcionario2 = new Funcionario(0,
				new NombreCompleto("Sofia", "Cabrera"),
				new Email("sofiacabrera@gmail.com"),
				new Password("Hola456#")
				);
			_context.Usuarios.Add(Funcionario2);


			Funcionario Funcionario3 = null;
			Funcionario3 = new Funcionario(0,
				new NombreCompleto("Francisco", "Castro"),
				new Email("panchocastro@gmail.com"),
				new Password("Hola456#")
				);
			_context.Usuarios.Add(Funcionario3);


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

		private void Envio()
		{
			Envio envioUrgente1 = new EnvioUrgente(0,
				tracking: new Tracking(345678),
				empleadoId: 1,
				clienteId: 4,
				peso: new Peso(10),
				estado: Estado.En_Proceso,
				seguimientos: new List<Seguimiento>(),
				fechaFinalizacion: null,
				fechaCreacion: DateTime.Now,
				direccionPostal: new DireccionPostal("Av. Libertador", 1234, 11200),
				esEficiente: false);
			_context.Envios.Add(envioUrgente1);

			Envio envioUrgente2 = new EnvioUrgente(0,
				tracking: new Tracking(345679),
				empleadoId: 1,
				clienteId: 4,
				peso: new Peso(7),
				estado: Estado.En_Proceso,
				seguimientos: new List<Seguimiento>(),
				fechaFinalizacion: null,
				fechaCreacion: DateTime.Now,
				direccionPostal: new DireccionPostal("Canelones", 567, 11100),
				esEficiente: false);
			_context.Envios.Add(envioUrgente2);

			Envio envioUrgente3 = new EnvioUrgente(0,
				tracking: new Tracking(345680),
				empleadoId: 3,
				clienteId: 5,
				peso: new Peso(3),
				estado: Estado.En_Proceso,
				seguimientos: new List<Seguimiento>(),
				fechaFinalizacion: null,
				fechaCreacion: DateTime.Now,
				direccionPostal: new DireccionPostal("Colonia", 789, 11300),
				esEficiente: false);
			_context.Envios.Add(envioUrgente3);

			Envio envioUrgente4 = new EnvioUrgente(0,
				tracking: new Tracking(345681),
				empleadoId: 2,
				clienteId: 6,
				peso: new Peso(12),
				estado: Estado.En_Proceso,
				seguimientos: new List<Seguimiento>(),
				fechaFinalizacion: null,
				fechaCreacion: DateTime.Now,
				direccionPostal: new DireccionPostal("18 de Julio", 1001, 11000),
				esEficiente: false);
			_context.Envios.Add(envioUrgente4);

			Envio envioUrgente5 = new EnvioUrgente(0,
				tracking: new Tracking(345682),
				empleadoId: 8,
				clienteId: 7,
				peso: new Peso(6),
				estado: Estado.En_Proceso,
				seguimientos: new List<Seguimiento>(),
				fechaFinalizacion: null,
				fechaCreacion: DateTime.Now,
				direccionPostal: new DireccionPostal("Rambla República", 202, 11400),
				esEficiente: false);
			_context.Envios.Add(envioUrgente5);

			Envio envioComun1 = new EnvioComun(0,
				tracking: new Tracking(123456),
				empleadoId: 2,
				clienteId: 4,
				peso: new Peso(5),
				estado: Estado.En_Proceso,
				seguimientos: new List<Seguimiento>(),
				fechaFinalizacion: null,
				fechaCreacion: DateTime.Now,
				agenciaId: 6);
			_context.Envios.Add(envioComun1);

			Envio envioComun2 = new EnvioComun(0,
				tracking: new Tracking(123457),
				empleadoId: 3,
				clienteId: 6,
				peso: new Peso(4),
				estado: Estado.En_Proceso,
				seguimientos: new List<Seguimiento>(),
				fechaFinalizacion: null,
				fechaCreacion: DateTime.Now,
				agenciaId: 2);
			_context.Envios.Add(envioComun2);

			Envio envioComun3 = new EnvioComun(0,
				tracking: new Tracking(123458),
				empleadoId: 9,
				clienteId: 5,
				peso: new Peso(8),
				estado: Estado.En_Proceso,
				seguimientos: new List<Seguimiento>(),
				fechaFinalizacion: null,
				fechaCreacion: DateTime.Now,
				agenciaId: 4);
			_context.Envios.Add(envioComun3);

			Envio envioComun4 = new EnvioComun(0,
				tracking: new Tracking(123459),
				empleadoId: 2,
				clienteId: 7,
				peso: new Peso(6),
				estado: Estado.En_Proceso,
				seguimientos: new List<Seguimiento>(),
				fechaFinalizacion: null,
				fechaCreacion: DateTime.Now,
				agenciaId: 1);
			_context.Envios.Add(envioComun4);

			Envio envioComun5 = new EnvioComun(0,
				tracking: new Tracking(123460),
				empleadoId: 2,
				clienteId: 4,
				peso: new Peso(9),
				estado: Estado.En_Proceso,
				seguimientos: new List<Seguimiento>(),
				fechaFinalizacion: null,
				fechaCreacion: DateTime.Now,
				agenciaId: 3);
			_context.Envios.Add(envioComun5);

			_context.SaveChanges();
		}


		private void Seguimiento()
		{


		}



	}
}
