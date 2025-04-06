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
        public Cliente(int id, Nombre nombre, string apellido, Email email, Password password) : base(id, nombre, apellido, email, password)
        {
        }
    }
}
