using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios.Auditorias
{
    public interface IRepositorioAuditoria :  
      IRepositorioAdd<Auditoria>
    { 
    }
}
