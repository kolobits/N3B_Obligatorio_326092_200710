using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios
{
    public record UsuarioDto(int Id,
                              string Nombre,
                              string Apellido,
                              string Email,
                              string Password
                              )
    {
    }
}
