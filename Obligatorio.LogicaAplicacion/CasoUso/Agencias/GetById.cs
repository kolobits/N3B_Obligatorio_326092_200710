using Obligatorio.CasoDeUsoCompartida.DTOs.Agencia;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias;

namespace Obligatorio.LogicaAplicacion.CasoUso.Agencias
{
	public class GetById : IGetById<AgenciaListadoDto>
	{
		private IRepositorioAgencia _repo;

		public GetById(IRepositorioAgencia repo)
		{
			_repo = repo;
		}


		public AgenciaListadoDto Execute(int id)
		{
			return AgenciaMapper.ToDto(_repo.GetById(id));
		}
	}
}
