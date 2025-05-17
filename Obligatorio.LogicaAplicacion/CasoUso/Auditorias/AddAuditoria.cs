using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Auditorias;

namespace Obligatorio.LogicaAplicacion.CasoUso.Auditorias
{
	public class AddAuditoria : IAdd<AuditoriaDto>
	{
		private IRepositorioAuditoria _repo;

		public AddAuditoria(IRepositorioAuditoria repo)
		{
			_repo = repo;
		}

		public void Execute(AuditoriaDto auditoriaDto)
		{
			_repo.Add(AuditoriaMapper.FromDto(auditoriaDto));
		}
	}
}
