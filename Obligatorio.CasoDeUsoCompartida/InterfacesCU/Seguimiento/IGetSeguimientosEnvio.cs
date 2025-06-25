using Obligatorio.CasoDeUsoCompartida.DTOs.Seguimientos;

namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Seguimiento
{
    public interface IGetSeguimientosEnvio
    {
        IEnumerable<SeguimientoDto> Execute(int idEnvio);
    }
}
