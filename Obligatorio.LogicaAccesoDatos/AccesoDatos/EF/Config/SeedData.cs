using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo.Agencia;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
	public class SeedData
	{
		private readonly ObligatorioContext _context;

		public SeedData(ObligatorioContext context)
		{
			_context = context;
		}

		public void Run()
		{
			if (!_context.Agencias.Any()) CargarAgencias();
		}

		private void CargarAgencias()
		{
			var agencia1 = new Agencia(
				0,
				new Nombre("Centro"),
				new DireccionPostal("18 de Julio", 1234, 11100),
				new Ubicacion(-34.9011, -56.1645)
			);

			var agencia2 = new Agencia(
				0,
				new Nombre("Pocitos"),
				new DireccionPostal("Ellauri", 456, 11300),
				new Ubicacion(-34.9075, -56.1486)
			);

			_context.Agencias.AddRange(agencia1, agencia2);
			_context.SaveChanges();
		}
	}
}