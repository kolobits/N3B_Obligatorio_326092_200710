using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.Vo.Agencia;
using Obligatorio.LogicaNegocio.Vo.Envio;
namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Agencia : IEntity
	{
		public int Id { get; set; }
		public Nombre Nombre { get; set; }
		public DireccionPostal DireccionPostal { get; set; }
		public Ubicacion Ubicacion { get; set; }

		protected Agencia() { } // Constructor protegido para EF Core

		public Agencia(int id, Nombre nombre, DireccionPostal direccionPostal, Ubicacion ubicacion)
		{
			Id = id;
			Nombre = nombre;
			DireccionPostal = direccionPostal;
			Ubicacion = ubicacion;
		}


	}
}
