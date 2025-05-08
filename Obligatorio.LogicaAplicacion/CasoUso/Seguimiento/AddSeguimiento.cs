using Obligatorio.CasoDeUsoCompartida.DTOs.Seguimientos;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Seguimientos;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Seguimiento
{
	public class AddSeguimiento : IAdd<SeguimientoDto>
	{
		private IRepositorioSeguimiento _repoSeguimiento;
		private IRepositorioUsuario _repoUsuario;
		private ISesionUsuarioActual _sesion;

		public AddSeguimiento(
							IRepositorioSeguimiento repoSeguimiento,
							IRepositorioUsuario repoUsuario,
							ISesionUsuarioActual sesion)
		{
			_repoSeguimiento = repoSeguimiento;
			_repoUsuario = repoUsuario;
			_sesion = sesion;
		}
		public void Execute(SeguimientoDto dto)
		{
			Empleado empleado = (Empleado)_repoUsuario.GetById(_sesion.ObtenerIdUsuario());

			_repoSeguimiento.Add(SeguimientoMapper.FromDto(dto, empleado.Id));

		}
	}

}
