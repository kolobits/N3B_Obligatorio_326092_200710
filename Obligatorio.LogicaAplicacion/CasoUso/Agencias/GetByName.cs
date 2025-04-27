using Obligatorio.CasoDeUsoCompartida.DTOs.Agencia;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Agencia;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias;

namespace Obligatorio.LogicaAplicacion.CasoUso.Agencias
{
	public class GetByName : IGetByName<AgenciaListadoDto>
	{
		private IRepositorioAgencia _repo;

		public GetByName(IRepositorioAgencia repo)
		{
			_repo = repo;
		}

		public AgenciaListadoDto Execute(string valor)
		{
			return AgenciaMapper.ToDto(_repo.GetByName(valor));
		}
	}
}
