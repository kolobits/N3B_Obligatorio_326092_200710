using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;
using System.Reflection.Emit;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
    public class EnvioConfiguration : IEntityTypeConfiguration<Envio>
    {
        public void Configure(EntityTypeBuilder<Envio> builder)
        {
            
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
        }
    }
}
