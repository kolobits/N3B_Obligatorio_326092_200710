using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
	public class UpdateUsuario : IUpdate<UsuarioDto>
	{
		private IRepositorioUsuario _repo;
		private IAdd<AuditoriaDto> _addAuditoria;
		private ISesionUsuarioActual _sesionUsuarioActual;

		public UpdateUsuario(IRepositorioUsuario repo,
							IAdd<AuditoriaDto> addAuditoria,
							ISesionUsuarioActual sesionUsuarioActual)
		{
			_repo = repo;
			_addAuditoria = addAuditoria;
			_sesionUsuarioActual = sesionUsuarioActual;
		}

		public void Execute(int id, UsuarioDto usuarioDto)
		{
            var existente = _repo.GetByEmail(usuarioDto.Email);
            if (existente != null)
            {
                throw new EmailRepetidoException($"El email {usuarioDto.Email} ya está registrado");
            }
            _repo.Update(id, UsuarioMapper.ForUpdate(_repo.GetById(id), usuarioDto));
			_addAuditoria.Execute(new AuditoriaDto(
				_sesionUsuarioActual.ObtenerIdUsuario(),
				DateTime.Now,
				"Usuario actualizado"
			));
		}
	}


}
