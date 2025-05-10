using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios
{
    public interface IRepositorioGetByTracking<T>
    {
        T GetByTracking(int tracking);
    }
}
