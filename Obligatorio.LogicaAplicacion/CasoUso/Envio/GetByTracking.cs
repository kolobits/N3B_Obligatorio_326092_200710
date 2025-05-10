using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;


namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
    public class GetByTracking : IGetByTracking<EnvioListadoDto>
    {
        private IRepositorioEnvio _repo;

        public GetByTracking(IRepositorioEnvio repo)
        {
            _repo = repo;
        }


        public EnvioListadoDto Execute(int tracking)
        {
            return EnvioMapper.ToDto(_repo.GetByTracking(tracking));
        }
    }
}
