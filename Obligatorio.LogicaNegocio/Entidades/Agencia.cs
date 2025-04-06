using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.Vo;
namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Agencia : IEntity
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
