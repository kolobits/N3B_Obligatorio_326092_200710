using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Usuarios
{
	public class GetAllUsuario : IGetAll<UsuarioListadoDto>
	{
		private IRepositorioUsuario _repo;

		public GetAllUsuario(IRepositorioUsuario repo)
		{
			_repo = repo;
		}

		public IEnumerable<UsuarioListadoDto> Execute()
		{
			return UsuarioMapper.ToListDto(_repo.GetAll());
		}
	}
}
