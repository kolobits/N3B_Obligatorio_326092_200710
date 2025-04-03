using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Vo
{
    public record Ubicacion
    {
        public double Latitud { get; }
        public double Longitud { get; }

        public Ubicacion(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Latitud))
                throw new LatitudException("Latitud inválida");
            if (string.IsNullOrEmpty(Longitud))
                throw new LongitudException("Longitud inválida");
        }

    }
}
