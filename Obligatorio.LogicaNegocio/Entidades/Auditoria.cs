using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Auditoria
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }

        public Auditoria(int id, Usuario usuario, DateTime fecha, string accion)
        {
            Id = id;
            Usuario = usuario;
            Fecha = fecha;
            Accion = accion;
        }

        public Auditoria()
        {
        }
    }
}
