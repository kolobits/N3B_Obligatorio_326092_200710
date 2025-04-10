
using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class ObligatorioContext : DbContext
    {

		public DbSet<Usuario> Usuarios { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(@"
						Data Source=(localdb)\MSSQLLocalDB;
						Initial Catalog=Obligatorio;
						Integrated Security=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Usuario>(usuario =>
			{
				// VO: Email
				usuario.OwnsOne(u => u.Email, email =>
				{
					email.Property(e => e.Value)
						 .HasColumnName("Email")
						 .IsRequired();
				});

				// VO: Password
				usuario.OwnsOne(u => u.Password, password =>
				{
					password.Property(p => p.Value)
							.HasColumnName("Password")
							.IsRequired();
				});

				// VO: NombreCompleto (con 2 atributos)
				usuario.OwnsOne(u => u.NombreCompleto, nombre =>
				{
					nombre.Property(n => n.Nombre)
						  .HasColumnName("Nombre")
						  .IsRequired();

					nombre.Property(n => n.Apellido)
						  .HasColumnName("Apellido")
						  .IsRequired();
				});
			});

		}
	}
}
