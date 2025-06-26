using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio
{
    public interface IGetEnviosFecha<T>
    {
        IEnumerable<T> Execute(DateTime? fechaInicio, DateTime? fechaFin, string estado, int clienteId);
    }
}
