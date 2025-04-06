using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Vo
{
    public class DireccionPostal
    {
        public string Calle { get; }
        public int Numero { get; }
        public int CodigoPostal { get; }
        public DireccionPostal(string calle,int numero,int codigoPostal)
        {
            Calle = calle;
            Numero = numero;
            CodigoPostal = codigoPostal;
           
        }
    }
}
