using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
	public class UpdateEnvio : IUpdate<EnvioDto>
	{
		private IRepositorioEnvio _repo;
		public UpdateEnvio(IRepositorioEnvio repo)
		{
			_repo = repo;
		}


		public void Execute(int id,EnvioDto dto)
        {
			  _repo.Update(id,EnvioMapper.ForUpdate(_repo.GetById(id)));
        }

    }
}
