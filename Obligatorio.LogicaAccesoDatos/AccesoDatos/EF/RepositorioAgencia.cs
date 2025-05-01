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

		//hacer sentencia en linq igual a la de arriba
		Agencia IRepositorioGetByName<Agencia>.GetByName(string nombre)
		{
			Agencia agenciaAEncontrar = null;
			foreach (Agencia agencia in _context.Agencias)
			{
				if (agencia.Nombre.Value == nombre)
				{
					agenciaAEncontrar = agencia;
				}
			}
			return agenciaAEncontrar;
		}

		public Agencia GetById(int id)
		{
			Agencia agenciaBuscada = null;
			foreach (Agencia agencia in _context.Agencias)
			{
				if (agencia.Id == id)
				{
					agenciaBuscada = agencia;
				}
			}
			return agenciaBuscada;
		}
	}
}
