using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
	public class EnvioUrgenteConfiguration : IEntityTypeConfiguration<EnvioUrgente>
	{
		public void Configure(EntityTypeBuilder<EnvioUrgente> builder)
		{

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

			builder.Property(e => e.EsEficiente)
				.HasColumnName("EsEficiente")
				.IsRequired();
		}
	}
}
