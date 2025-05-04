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
				.ToList();
		}

		public void Update(Envio envio)
		{
			var envioExistente = _context.Envios.Find(envio.Id);
			if (envioExistente != null)
			{
				envioExistente.Estado = envio.Estado;
				_context.SaveChanges();
			}
		}

		public Envio GetById(int id)
		{
			return _context.Envios.FirstOrDefault(e => e.Id == id);
		}
	}


}
