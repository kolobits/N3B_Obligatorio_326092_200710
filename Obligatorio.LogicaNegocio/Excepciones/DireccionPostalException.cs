using Obligatorio.LogicaNegocio.Excepciones.Agencia;

namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class DireccionPostalException : AgenciaException
    {
        public DireccionPostalException() { }
        public DireccionPostalException(string mensaje) : base(mensaje)
        {
        }
    }
}