using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
	public class GetAllEnviosCliente : IGetAllEnviosCliente<EnvioListadoDto>
	{
		private IRepositorioEnvio _repo;
		private IRepositorioUsuario _repoUsuario;

		public GetAllEnviosCliente(IRepositorioEnvio repo, IRepositorioUsuario repoUsuario)
		{
			_repo = repo;
			_repoUsuario = repoUsuario;
		}


		public IEnumerable<EnvioListadoDto> Execute(int id)
		{
			Console.WriteLine("Buscando usuario ID: " + id);
			var usuario = _repoUsuario.GetById(id);

			if (usuario == null)
				throw new NotFoundException("Usuario no encontrado.");
			return EnvioMapper.ToListDto(_repo.GetAllEnviosCliente(id));
		}
	}
}
