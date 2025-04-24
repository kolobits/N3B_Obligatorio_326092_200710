using Obligatorio.CasoDeUsoCompartida.InterfacesCU;

namespace Obligatorio.WebApp.Servicios
{
	public class SesionUsuarioActual : ISesionUsuarioActual
	{
		private readonly IHttpContextAccessor _accessor;

		public SesionUsuarioActual(IHttpContextAccessor accessor)
		{
			_accessor = accessor;
		}

		public int ObtenerIdUsuario()
		{
			return _accessor.HttpContext?.Session?.GetInt32("IdUsuario") ?? 0;
		}
	}
}
