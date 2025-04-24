using Obligatorio.LogicaNegocio.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class EnvioUrgente: Envio
    {
        public DireccionPostal direccionPostal { get; set; }
        public bool EsEficiente { get; set; }
        public EnvioUrgente(int id, Tracking tracking, Empleado empleado, Cliente cliente, Peso peso, Estado estado, List<Seguimiento> seguimientos, DireccionPostal direccionPostal, bool EsEficiente) : base(id, tracking, empleado, cliente, peso, estado, seguimientos)
        {
        }
        protected EnvioUrgente()
        {
        }
    }
}
