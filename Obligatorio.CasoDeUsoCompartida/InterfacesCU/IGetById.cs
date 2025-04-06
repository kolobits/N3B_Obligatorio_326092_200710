using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU
{
    public interface IGetById<T>
    {
        T Execute(int id);
    }
}
