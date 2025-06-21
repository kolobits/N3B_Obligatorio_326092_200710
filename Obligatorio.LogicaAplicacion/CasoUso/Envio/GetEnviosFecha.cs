using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
    public class GetEnviosFecha: IGetEnviosFecha<EnvioListadoDto>
    {
        private IRepositorioEnvio _repo;

        public GetEnviosFecha(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        public IEnumerable<EnvioListadoDto> Execute(DateTime? fechaCreacion, DateTime? fechaFinalizacion, string estado, int clienteId)
        {
   
            return EnvioMapper.ToListDto(_repo.GetEnviosFecha(fechaCreacion,fechaFinalizacion, estado, clienteId));
        }
    }

}
