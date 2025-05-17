using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
	public class AddUsuario : IAdd<UsuarioDto>
	{
		private IRepositorioUsuario _repo;
		private IAdd<AuditoriaDto> _addAuditoria;
		private ISesionUsuarioActual _sesionUsuarioActual;

		public AddUsuario(
						IRepositorioUsuario repo,
						IAdd<AuditoriaDto> addAuditoria,
						ISesionUsuarioActual sesionUsuarioActual)
		{
			_repo = repo;
			_addAuditoria = addAuditoria;
			_sesionUsuarioActual = sesionUsuarioActual;
		}


		public void Execute(UsuarioDto usuarioDto)
		{
			var existente = _repo.GetByEmail(usuarioDto.Email);
            if (existente != null)
            {
                throw new EmailRepetidoException($"El email {usuarioDto.Email} ya está registrado");
            }

			_repo.Add(UsuarioMapper.FromDto(usuarioDto));

			_addAuditoria.Execute(new AuditoriaDto(
				_sesionUsuarioActual.ObtenerIdUsuario(),
				DateTime.Now,
				"Usuario agregado"
			));
		}

	}
}
