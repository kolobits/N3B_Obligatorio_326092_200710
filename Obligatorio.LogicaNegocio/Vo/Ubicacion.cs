
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
        }

        

    }
}
