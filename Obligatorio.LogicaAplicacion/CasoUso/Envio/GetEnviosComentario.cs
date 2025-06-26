using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
	public class GetEnviosComentario : IGetEnviosComentario<EnvioListadoDto>
	{
		private IRepositorioEnvio _repo;
		private IRepositorioUsuario _repoUsuario;

		public GetEnviosComentario(IRepositorioEnvio repo, IRepositorioUsuario repoUsuario)
		{
			_repo = repo;
			_repoUsuario = repoUsuario;
		}

		public IEnumerable<EnvioListadoDto> Execute(string comentario, int clienteId)
		{
			var usuario = _repoUsuario.GetById(clienteId);
			if (usuario == null)
				throw new NotFoundException("Usuario no encontrado.");

			return EnvioMapper.ToListDto(_repo.GetEnviosComentario(comentario, clienteId));
		}
	}
}
