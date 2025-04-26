using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Seguimiento
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get;set; }
        public Empleado Empleado { get; set; }

        public Seguimiento(int id, string comentario, DateTime fecha, Empleado empleado)
        {
            Id = id;
            Comentario = comentario;
            Fecha = fecha;
            Empleado = empleado;
        }

        protected Seguimiento() { }
    }
}
