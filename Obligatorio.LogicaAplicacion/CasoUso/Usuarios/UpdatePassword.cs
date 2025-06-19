using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using Obligatorio.LogicaNegocio.Vo.Usuario;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
	public class UpdatePassword : IUpdate<UsuarioDtoUpdate>
	{
		private IRepositorioUsuario _repo;
		private ISesionUsuarioActual _sesionUsuarioActual;

		public UpdatePassword(IRepositorioUsuario repo,
							ISesionUsuarioActual sesionUsuarioActual)
		{
			_repo = repo;
			_sesionUsuarioActual = sesionUsuarioActual;
		}

		public void Execute(int id, UsuarioDtoUpdate dto)
		{
			var usuario = _repo.GetById(id);
			if (usuario == null)
				throw new NotFoundException("Usuario no encontrado.");

			var passActual = new Password(dto.PasswordActual);
			if (!usuario.Password.Equals(passActual))
				throw new BadRequestException("Contraseña actual incorrecta.");

			usuario.Password = new Password(dto.PasswordNueva);
			_repo.Update(id, UsuarioMapper.ForUpdatePassword(_repo.GetById(id), dto));

		}
	}
}
