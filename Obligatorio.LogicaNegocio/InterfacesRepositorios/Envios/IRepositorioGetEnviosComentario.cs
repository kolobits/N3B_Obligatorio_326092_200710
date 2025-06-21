using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios
{
    public interface IRepositorioGetEnviosComentario<T>
    {
        IEnumerable<T> GetEnviosComentario(string comentario, int id);
    }
}
