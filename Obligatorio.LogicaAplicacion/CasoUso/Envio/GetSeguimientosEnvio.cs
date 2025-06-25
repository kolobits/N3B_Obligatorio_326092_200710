using Obligatorio.CasoDeUsoCompartida.DTOs.Seguimientos;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Seguimiento;
using Obligatorio.Infraestructura.AccesoDatos.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
    public class GetSeguimientosEnvio : IGetSeguimientosEnvio
    {
        private readonly IRepositorioEnvio _repositorioEnvio;
        public GetSeguimientosEnvio(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }
        public IEnumerable<SeguimientoDto> Execute(int envioId)
        {
            var envio = _repositorioEnvio.GetById(envioId);
            if (envio == null)
                throw new NotFoundException("Envío no encontrado.");

            var seguimientos = envio.Seguimientos ?? new List<LogicaNegocio.Entidades.Seguimiento>();
            return Mapper.SeguimientoMapper.ToDtoList(seguimientos.OrderBy(s => s.Fecha));

        }
    }
}
