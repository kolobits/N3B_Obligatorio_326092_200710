using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios
{
    public interface IRepositorioGetEnviosFecha<T>
    {
        IEnumerable<T> GetEnviosFecha(DateTime? fechaCreacion, DateTime? fechaFinalizacion, string estado,int id);
    }
}
