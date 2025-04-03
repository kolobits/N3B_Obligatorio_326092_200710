using Obligatorio.LogicaNegocio.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Agencia
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public int DireccionPostal { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public Agencia(int id, Nombre nombre, int direccionPostal,Ubicacion ubicacion)
        {
            Id = id;
            Nombre = nombre;
            DireccionPostal = direccionPostal;
            Ubicacion = ubicacion;
        }


    }
}
