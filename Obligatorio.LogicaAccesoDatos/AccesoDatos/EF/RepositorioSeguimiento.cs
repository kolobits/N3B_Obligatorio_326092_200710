using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Seguimientos;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
	public class RepositorioSeguimiento : IRepositorioSeguimiento
	{
		private ObligatorioContext _context;
		public RepositorioSeguimiento(ObligatorioContext context)
		{
			_context = context;
		}

		public void Add(Seguimiento obj)
		{
			_context.Seguimientos.Add(obj);
			_context.SaveChanges();
		}

	}
}
