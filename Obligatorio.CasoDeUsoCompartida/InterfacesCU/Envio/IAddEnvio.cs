using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio
{
    public interface IAddEnvio<T>
    {
        void Execute(T obj);
    }
}
