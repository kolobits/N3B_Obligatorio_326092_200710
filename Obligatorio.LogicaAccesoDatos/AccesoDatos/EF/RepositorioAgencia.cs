using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
	public class RepositorioAgencia : IRepositorioAgencia
	{
		private ObligatorioContext _context;

		public RepositorioAgencia(ObligatorioContext context)
		{
			_context = context;
		}

		public void Add(Agencia obj)
		{
			_context.Agencias.Add(obj);
			_context.SaveChanges();
		}
		public IEnumerable<Agencia> GetByName(string value)
		{
			return _context.Agencias
				.Where(agencia => agencia.Nombre.Value.ToLower().Contains(value.ToLower()));
		}

		Agencia IRepositorioGetByName<Agencia>.GetByName(string nombre)
		{
			return _context.Agencias
				.FirstOrDefault(agencia => agencia.Nombre.Value.ToLower().Contains(nombre.ToLower()));
		}

		public Agencia GetById(int id)
		{
			return _context.Agencias
					.FirstOrDefault(agencia => agencia.Id == id);
		}

		public IEnumerable<Agencia> GetAll()
		{
			return _context.Agencias.ToList();
		}
	}
}
