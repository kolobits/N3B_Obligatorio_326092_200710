using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
	public class UpdateUsuario : IUpdate<UsuarioDto>
	{
		private IRepositorioUsuario _repo;
		private IAddAuditoria<AuditoriaDto> _addAuditoria;
		private ISesionUsuarioActual _sesionUsuarioActual;

		public UpdateUsuario(IRepositorioUsuario repo,
							IAddAuditoria<AuditoriaDto> addAuditoria,
							ISesionUsuarioActual sesionUsuarioActual)
		{
			_repo = repo;
			_addAuditoria = addAuditoria;
			_sesionUsuarioActual = sesionUsuarioActual;
		}

		public void Execute(int id, UsuarioDto obj)
		{
			_repo.Update(id, Mapper.UsuarioMapper.ForUpdate(_repo.GetById(id), obj));
			_addAuditoria.Execute(new AuditoriaDto(
				_sesionUsuarioActual.ObtenerIdUsuario(),
				DateTime.Now,
				"Usuario actualizado"
			));
		}
	}


}
