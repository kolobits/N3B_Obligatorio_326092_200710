using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Auditorias;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
	public class RepositorioAuditoria : IRepositorioAuditoria
	{
		private ObligatorioContext _context;

		public RepositorioAuditoria(ObligatorioContext context)
		{
			_context = context;
		}
		public void Add(Auditoria obj)
		{
			_context.Auditorias.Add(obj);
			_context.SaveChanges();
		}
	}
}
