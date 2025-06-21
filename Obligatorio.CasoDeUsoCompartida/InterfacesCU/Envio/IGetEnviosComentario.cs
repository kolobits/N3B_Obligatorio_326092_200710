using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio
{
    public interface IGetEnviosComentario<T>
    {
        IEnumerable<T> Execute(string comentario, int clienteId);
    }
}
