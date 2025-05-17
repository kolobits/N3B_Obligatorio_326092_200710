using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.Vo.Envio
{
    public class DireccionPostal
    {
        public string Calle { get; }
        public int? Numero { get; }
        public int? CodigoPostal { get; }
        protected DireccionPostal() { } // Constructor protegido para EF Core
        public DireccionPostal(string calle, int? numero, int? codigoPostal)
        {
            Calle = calle;
            Numero = numero;
            CodigoPostal = codigoPostal;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Calle))
                throw new DireccionPostalException("La calle no puede estar vacía.");

            if (Calle.Length > 50)
                throw new DireccionPostalException("La calle no puede superar los 50 caracteres.");

            if (Numero <= 0)
                throw new DireccionPostalException("El número debe ser mayor que cero.");

            if (CodigoPostal <= 0)
                throw new DireccionPostalException("El código postal debe ser mayor que cero.");
        }
    }


}