using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    class AuditoriaMapper
    {
        public static Auditoria FromDto(AuditoriaDto auditoriaDto)
        {
            return new Auditoria(0,
                                 auditoriaDto.Usuario,
                                 auditoriaDto.Fecha,
                                 auditoriaDto.Accion);
        }
    }
}
