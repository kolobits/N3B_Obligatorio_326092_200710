using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
	public class EnvioConfiguration : IEntityTypeConfiguration<Envio>
	{

		public void Configure(EntityTypeBuilder<Envio> builder)
		{

			builder.HasDiscriminator<string>("Discriminator")
				   .HasValue<EnvioComun>("EnvioComun")
				   .HasValue<EnvioUrgente>("EnvioUrgente");


			// VO: Tracking
			builder.OwnsOne(e => e.Tracking, tracking =>
			{
				tracking.Property(u => u.Value)
					 .HasColumnName("Tracking")
					 .IsRequired();
			});

			// VO: Peso
			builder.OwnsOne(e => e.Peso, peso =>
			{
				peso.Property(e => e.Value)
						.HasColumnName("Peso")
						.IsRequired();
			});

			builder.HasOne(e => e.Empleado)
				.WithMany()
				.HasForeignKey("EmpleadoId")
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(e => e.Cliente)
				.WithMany()
				.HasForeignKey("ClienteId")
				.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
