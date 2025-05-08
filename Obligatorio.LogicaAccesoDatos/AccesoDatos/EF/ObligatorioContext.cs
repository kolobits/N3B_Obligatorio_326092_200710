
using Microsoft.EntityFrameworkCore;
using Obligatorio.Infraestructura.AccesoDatos.EF.Config;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
	public class ObligatorioContext : DbContext
	{

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Empleado> Empleados { get; set; }
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Agencia> Agencias { get; set; }
		public DbSet<Administrador> Administradores { get; set; }
		public DbSet<Funcionario> Funcionarios { get; set; }
		public DbSet<Envio> Envios { get; set; }
		public DbSet<Auditoria> Auditorias { get; set; }
		public DbSet<EnvioUrgente> EnviosUrgentes { get; set; }
		public DbSet<EnvioComun> EnviosComunes { get; set; }
		public DbSet<Seguimiento> Seguimientos { get; set; }



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
			modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
			modelBuilder.ApplyConfiguration(new EnvioConfiguration());
			modelBuilder.ApplyConfiguration(new AgenciaConfiguration());
			modelBuilder.ApplyConfiguration(new EnvioUrgenteConfiguration());
			modelBuilder.ApplyConfiguration(new EnvioComunConfiguration());


		}

	}
}
