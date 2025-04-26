using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.CasoDeUsoCompartida.DTOs.Envios
{
    public record EnvioDto(
                           string Tipo,
                           string Email,
                           string Destino,
                           int    Peso
                           )
    {
    }
}

