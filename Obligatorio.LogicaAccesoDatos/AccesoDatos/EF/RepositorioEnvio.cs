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
			//_context.Attach(obj.Empleado);
			//_context.Attach(obj.Cliente);

			//if (obj is EnvioComun envioComun && envioComun.AgenciaRetiro != null)
			//{
			//	_context.Attach(envioComun.AgenciaRetiro);
			//}
			_context.Envios.Add(obj);
			_context.SaveChanges();
		}

		public IEnumerable<Envio> GetAll()
		{
			return _context.Envios.ToList();
		}
	}
}