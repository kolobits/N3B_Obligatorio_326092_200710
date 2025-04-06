using Obligatorio.LogicaNegocio.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Envio
    {
        public int Id { get; set; }
        public Tracking Tracking { get; set; }
        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }
        public Peso Peso { get; set; }
        public Estado Estado { get; set; }
        public List<Seguimiento> Seguimientos { get; set; }

        public Envio(int id, Tracking tracking, Empleado empleado, Cliente cliente, Peso peso,Estado estado, List<Seguimiento> seguimientos)
        {
            Id = id;
            Tracking = tracking;
            Empleado = empleado;
            Cliente = cliente;
            Estado = estado;
            Peso = peso;
            Seguimientos = seguimientos;
        }
    }
}
