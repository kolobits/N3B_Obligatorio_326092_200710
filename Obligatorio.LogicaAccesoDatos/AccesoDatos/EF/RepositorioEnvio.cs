using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
	public class RepositorioEnvio : IRepositorioEnvio
	{
		private ObligatorioContext _context;

		public RepositorioEnvio(ObligatorioContext context)
		{
			_context = context;
		}
		public void Add(Envio obj)
		{

			_context.Envios.Add(obj);
			_context.SaveChanges();
		}

		public IEnumerable<Envio> GetAll()
		{
			return _context.Envios
				.Include(e => e.Cliente)
					.ThenInclude(c => c.NombreCompleto)
				.Include(e => e.Empleado)
					.ThenInclude(emp => emp.NombreCompleto)
				.Include(e => e.Tracking)
                .Include(e => e.Seguimientos)
                .ToList();
		}

        public void Update(int id,Envio obj)
		{
			Envio unE = GetById(id);
			if (unE != null)
			{
				unE.Update(obj);
                _context.Envios.Update(unE);
				_context.SaveChanges();
			}
		}

		public Envio GetById(int id)
		{
			return _context.Envios.FirstOrDefault(e => e.Id == id);
		}
	}


}
