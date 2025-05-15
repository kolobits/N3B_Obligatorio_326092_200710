using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;


namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
    public class GetAllEnvio : IGetAll<EnvioListadoDto>
    {
        private IRepositorioEnvio _repo;

        public GetAllEnvio(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        public IEnumerable<EnvioListadoDto> Execute()
        {
            return EnvioMapper.ToListDto(_repo.GetAll());
        }
    }
}
