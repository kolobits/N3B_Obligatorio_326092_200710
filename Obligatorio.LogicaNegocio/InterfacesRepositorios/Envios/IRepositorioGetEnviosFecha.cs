using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios
{
    public interface IRepositorioGetEnviosFecha<T>
    {
        IEnumerable<T> GetEnviosFecha(DateTime? fechaInicio, DateTime? fechaFin, string estado,int id);
    }
}
