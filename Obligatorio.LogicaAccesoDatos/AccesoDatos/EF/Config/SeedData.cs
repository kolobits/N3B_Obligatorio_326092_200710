using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo.Agencia;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
	public class SeedData
	{
		ObligatorioContext _context;

		public SeedData(ObligatorioContext context)
		{
			_context = context;
		}

		public void run()
		{
			if (!_context.Agencias.Any()) Agencia();
		}

		private void Agencia()
		{
			Agencia unA = null;
			unA = new Agencia(0, new Nombre("Rivera"), new DireccionPostal("Falsa", 123, 54300), new Ubicacion(230000, 450000));
			_context.Agencias.Add(unA);

			_context.SaveChanges();
		}
	}
}