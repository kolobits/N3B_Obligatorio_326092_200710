using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario
{
    public interface IAddUsuario<T>
    {
        void Execute(T obj);
    }
}
