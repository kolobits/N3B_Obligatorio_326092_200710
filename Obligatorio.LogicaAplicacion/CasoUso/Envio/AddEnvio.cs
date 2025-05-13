using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using Obligatorio.LogicaNegocio.Vo.Agencia;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
	public class AddEnvio : IAdd<EnvioDto>
	{
		private IRepositorioEnvio _repoEnvio;
		private IRepositorioUsuario _repoUsuario;
		private IRepositorioAgencia _repoAgencia;
		private ISesionUsuarioActual _sesion;

		public AddEnvio(IRepositorioEnvio repoEnvio,
						IRepositorioUsuario repoUsuario,
						IRepositorioAgencia repoAgencia,
						ISesionUsuarioActual sesion)
		{
			_repoEnvio = repoEnvio;
			_repoUsuario = repoUsuario;
			_repoAgencia = repoAgencia;
			_sesion = sesion;
		}

		public void Execute(EnvioDto dto)
		{

			Empleado empleado = (Empleado)_repoUsuario.GetById(_sesion.ObtenerIdUsuario());
			Cliente cliente = (Cliente)_repoUsuario.GetByEmail(dto.Email);

			if (cliente == null)
				throw new Exception("Cliente no encontrado.");

			Agencia? agencia = null;
			DireccionPostal? direccionPostal = null;


			if (dto.Tipo.ToLower() == "comun")
			{
				EnvioComun e = EnvioMapper.FromDtoEnvioComun(dto, empleado.Id, cliente.Id);
				_repoEnvio.Add(e);

			}
			else if (dto.Tipo.ToLower() == "urgente")
			{
				_repoEnvio.Add(EnvioMapper.FromDtoEnvioUrgente(dto, empleado.Id, cliente.Id));
			}

		}
	}
}

