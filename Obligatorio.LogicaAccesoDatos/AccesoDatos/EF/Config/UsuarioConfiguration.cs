
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
	public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.HasDiscriminator<string>("Discriminator")
				   .HasValue<Cliente>("Cliente")
				   .HasValue<Empleado>("Empleado")
				   .HasValue<Administrador>("Administrador")
				   .HasValue<Funcionario>("Funcionario");


			// VO: Email
			builder.OwnsOne(u => u.Email, email =>
			{
				email.Property(e => e.Value)
					 .HasColumnName("Email")
					 .IsRequired();
			});
			// VO: Password
			builder.OwnsOne(u => u.Password, password =>
			{
				password.Property(p => p.Value)
						.HasColumnName("Password")
						.IsRequired();
			});
			// VO: NombreCompleto (con 2 atributos)
			builder.OwnsOne(u => u.NombreCompleto, nombre =>
			{
				nombre.Property(n => n.Nombre)
					  .HasColumnName("Nombre")
					  .IsRequired();
				nombre.Property(n => n.Apellido)
					  .HasColumnName("Apellido")
					  .IsRequired();
			});
		}
	}
}
