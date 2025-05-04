using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
	public class UpdateEnvio : IUpdateEnvio<EnvioUpdateDto>
	{
		private IRepositorioEnvio _repo;
		public UpdateEnvio(IRepositorioEnvio repo)
		{
			_repo = repo;
		}

		public void Execute(EnvioUpdateDto dto)
		{
			var envio = _repo.GetById(dto.Id);

			envio.Estado = Estado.Finalizado;

			_repo.Update(envio);
		}
	}
}
