using Obligatorio.LogicaNegocio.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Cliente : Usuario
    {
        public Cliente(int id, NombreCompleto nombreCompleto, Email email, Password password) : base(id, nombreCompleto, email, password)
        {
        }
    }
}
