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
        public int Tracking { get; set; }
        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }
        public double Peso { get; set; }
        //public Estado Estado { get; set; }
        public List<Seguimiento> Seguimientos { get; set; }

        public Envio(int id, int tracking, Empleado empleado, Cliente cliente, double peso, List<Seguimiento> seguimientos)
        {
            Id = id;
            Tracking = tracking;
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Seguimientos = seguimientos;
        }
    }
}
