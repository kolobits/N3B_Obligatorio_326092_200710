using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
	public class GetAllEnviosCliente : IGetAllEnviosCliente<EnvioListadoDto>
	{
		private IRepositorioEnvio _repo;

		public GetAllEnviosCliente(IRepositorioEnvio repo)
		{
			_repo = repo;
		}


		public IEnumerable<EnvioListadoDto> Execute(int id)
		{
			var usuario = _repo.GetById(id);
			if (usuario == null)
				throw new NotFoundException("Usuario no encontrado.");

			return EnvioMapper.ToListDto(_repo.GetAllEnviosCliente(id));
		}
	}
}
