using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
	public class RemoveUsuario : IRemove
	{
		private IRepositorioUsuario _repo;
		private IAddAuditoria<AuditoriaDto> _addAuditoria;
		private ISesionUsuarioActual _sesionUsuarioActual;

		public RemoveUsuario(IRepositorioUsuario repo,
							IAddAuditoria<AuditoriaDto> addAuditoria,
							ISesionUsuarioActual sesionUsuarioActual)
		{
			_repo = repo;
			_addAuditoria = addAuditoria;
			_sesionUsuarioActual = sesionUsuarioActual;
		}
		public void Execute(int id)
		{
			_repo.Remove(id);
			_addAuditoria.Execute(new AuditoriaDto(
				_sesionUsuarioActual.ObtenerIdUsuario(),
				DateTime.Now,
				"Usuario eliminado"
				));
		}

	}
}
