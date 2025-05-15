using Obligatorio.CasoDeUsoCompartida.DTOs.Agencia;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias;

namespace Obligatorio.LogicaAplicacion.CasoUso.Agencias
{
	public class GetAllAgencia : IGetAll<AgenciaListadoDto>
	{
		private IRepositorioAgencia _repo;
		public GetAllAgencia(IRepositorioAgencia repo)
		{
			_repo = repo;
		}
		public IEnumerable<AgenciaListadoDto> Execute()
		{
			return AgenciaMapper.ToListDto(_repo.GetAll());
		}
	}
}
