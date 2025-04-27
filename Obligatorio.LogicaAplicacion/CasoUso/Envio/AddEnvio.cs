using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
	public class AddEnvio : IAddEnvio<EnvioDto>
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
				if (string.IsNullOrWhiteSpace(dto.Agencia))
					throw new Exception("Debe ingresar la agencia para el envío común.");

				agencia = _repoAgencia.GetByName(dto.Agencia);

				if (agencia == null)
					throw new Exception("Agencia no encontrada.");
			}
			else if (dto.Tipo.ToLower() == "urgente")
			{
				if (string.IsNullOrEmpty(dto.Calle))
					throw new Exception("Debe ingresar la dirección postal para el envío urgente.");

				direccionPostal = new DireccionPostal(dto.Calle, dto.Numero, dto.CodigoPostal);
			}
			else
			{
				throw new Exception("Tipo de envío inválido.");
			}

			_repoEnvio.Add(EnvioMapper.FromDto(dto, empleado, cliente, agencia, direccionPostal));
		}
	}
}

