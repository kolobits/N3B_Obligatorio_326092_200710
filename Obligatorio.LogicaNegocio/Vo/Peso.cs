using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Vo
{
    public class Peso
    {
        public double Value { get; }

        public Peso(double value)
        {
            Value = value;
            Validar();
        }

        protected Peso() { }
        private void Validar()
        {

        }

    }
}
