using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
	public class AgenciaConfiguration : IEntityTypeConfiguration<Agencia>
	{
		public void Configure(EntityTypeBuilder<Agencia> builder)
		{

			builder.OwnsOne(e => e.Nombre, nombre =>
			{
				nombre.Property(u => u.Value)
					 .HasColumnName("Nombre")
					 .IsRequired();
			});

			builder.OwnsOne(u => u.Ubicacion, ubicacion =>
			{
				ubicacion.Property(n => n.Latitud)
					  .HasColumnName("Latitud")
					  .IsRequired();
				ubicacion.Property(n => n.Longitud)
					  .HasColumnName("Longitud")
					  .IsRequired();
			});

			builder.OwnsOne(u => u.DireccionPostal, direccionPostal =>
			{
				direccionPostal.Property(n => n.Calle)
					  .HasColumnName("Calle")
					  .IsRequired();
				direccionPostal.Property(n => n.Numero)
					  .HasColumnName("Numero")
					  .IsRequired();
				direccionPostal.Property(n => n.CodigoPostal)
					  .HasColumnName("Codigo Postal")
					  .IsRequired();
			});
		}
	}
}
