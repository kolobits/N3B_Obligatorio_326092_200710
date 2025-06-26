using Microsoft.EntityFrameworkCore;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
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

		public IEnumerable<Envio> GetAllEnviosCliente(int clienteId)
		{
			return _context.Envios
				.Include(e => e.Cliente)
					.ThenInclude(c => c.NombreCompleto)
				.Include(e => e.Empleado)
					.ThenInclude(emp => emp.NombreCompleto)
				.Include(e => e.Tracking)
				.Include(e => e.Seguimientos)
				.Where(e => e.ClienteId == clienteId)
                .OrderBy(e => e.FechaCreacion)
                .ToList();
		}


		public void Update(int id, Envio obj)
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
			return _context.Envios
				.Include(e => e.Seguimientos)
				.FirstOrDefault(e => e.Id == id);
		}


		public Envio GetByTracking(int tracking)
		{
			var envioExitoso = _context.Envios
				.Include(e => e.Cliente)
					.ThenInclude(c => c.NombreCompleto)
				.Include(e => e.Empleado)
					.ThenInclude(emp => emp.NombreCompleto)
				.Include(e => e.Seguimientos)
				.Include(e => e.Tracking)
				.FirstOrDefault(e => e.Tracking.Value == tracking);

			if (envioExitoso == null)
			{
				throw new NotFoundException("No se encontró un envío con ese número de tracking");
			}
			return envioExitoso;
		}

		public IEnumerable<Envio> GetEnviosFecha(DateTime? fechaInicio, DateTime? fechaFin, string estado, int clienteId)
		{

			var query = _context.Envios
                .Include(e => e.Cliente)
                    .ThenInclude(c => c.NombreCompleto)
                .Include(e => e.Empleado)
                    .ThenInclude(emp => emp.NombreCompleto)
                .Include(e => e.Tracking)
                .Include(e => e.Seguimientos)
                .Where(e => e.ClienteId == clienteId);

            Estado? estadoEnum = null;
            if (!string.IsNullOrEmpty(estado))
            {
                if (Enum.TryParse(estado, true, out Estado estadoParsed))
                {
                    estadoEnum = estadoParsed;
                }
            }
            

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
				query = query.Where(e => e.FechaCreacion >= fechaInicio && e.FechaCreacion <= fechaFin);

            }

            if (estadoEnum.HasValue)
            {
                query = query.Where(e => e.Estado == estadoEnum.Value);
            }

            return query
                .OrderBy(e => e.Tracking.Value)
                .ToList();
        }

        public IEnumerable<Envio> GetEnviosComentario(string comentario,int clienteId)
        {
            return _context.Envios
                .Include(e => e.Cliente)
                    .ThenInclude(c => c.NombreCompleto)
                .Include(e => e.Empleado)
                    .ThenInclude(emp => emp.NombreCompleto)
                .Include(e => e.Tracking)
                .Include(e => e.Seguimientos)
                .Where(e => e.ClienteId == clienteId &&
                               e.Seguimientos.Any(s =>
								 s.Comentario != null &&
								 s.Comentario.ToLower().Contains(comentario.ToLower())))
				.OrderBy(e=>e.FechaCreacion)
                .ToList();   
        }
    }

}
