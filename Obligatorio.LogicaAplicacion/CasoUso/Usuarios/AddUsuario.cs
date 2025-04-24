using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
	public class AddUsuario : IAddUsuario<UsuarioDto>
	{
		private IRepositorioUsuario _repo;
		private IAddAuditoria<AuditoriaDto> _addAuditoria;
		private ISesionUsuarioActual _sesionUsuarioActual;

		public AddUsuario(
						IRepositorioUsuario repo,
						IAddAuditoria<AuditoriaDto> addAuditoria,
						ISesionUsuarioActual sesionUsuarioActual)
		{
			_repo = repo;
			_addAuditoria = addAuditoria;
			_sesionUsuarioActual = sesionUsuarioActual;
		}


		public void Execute(UsuarioDto usuarioDto)
		{
			_repo.Add(UsuarioMapper.FromDto(usuarioDto));

			_addAuditoria.Execute(new AuditoriaDto(
				_sesionUsuarioActual.ObtenerIdUsuario(),
				DateTime.Now,
				"Usuario agregado"
			));
		}

	}
}
