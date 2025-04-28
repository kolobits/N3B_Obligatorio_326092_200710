using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
	public class EnvioComunConfiguration : IEntityTypeConfiguration<EnvioComun>
	{
		public void Configure(EntityTypeBuilder<EnvioComun> builder)
		{
			builder.HasOne(u => u.AgenciaRetiro)
			.WithMany()
			.HasForeignKey("AgenciaRetiroId")
			.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
