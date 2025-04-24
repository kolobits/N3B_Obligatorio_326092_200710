using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.CasoDeUsoCompartida.DTOs
{
    public record AuditoriaDto (
                                Usuario Usuario,
                                DateTime Fecha,
                                string Accion
                                )
    
    {
    }
}
