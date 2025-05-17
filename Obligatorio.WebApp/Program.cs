
using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.DTOs.Agencia;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.DTOs.Seguimientos;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Agencia;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.Infraestructura.AccesoDatos.EF;
using Obligatorio.Infraestructura.AccesoDatos.EF.Config;
using Obligatorio.LogicaAplicacion.CasoUso.Agencias;
using Obligatorio.LogicaAplicacion.CasoUso.Auditorias;
using Obligatorio.LogicaAplicacion.CasoUso.Envio;
using Obligatorio.LogicaAplicacion.CasoUso.Seguimiento;
using Obligatorio.LogicaAplicacion.CasoUso.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Agencias;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Auditorias;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Seguimientos;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using Obligatorio.WebApp.Servicios;

namespace Obligatorio.WebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//Inyecto la Session
			builder.Services.AddSession();

			// Add services to the container.
			builder.Services.AddControllersWithViews();


			// Inyecciones para los Caso de Uso de Usuario
			builder.Services.AddScoped<IAdd<UsuarioDto>, AddUsuario>();
			builder.Services.AddScoped<IGetAll<UsuarioListadoDto>, GetAllUsuario>();
			builder.Services.AddScoped<IGetById<UsuarioListadoDto>, LogicaAplicacion.CasoUso.Usuarios.GetById>();
			builder.Services.AddScoped<IRemove, RemoveUsuario>();
			builder.Services.AddScoped<IUpdate<UsuarioDto>, UpdateUsuario>();
			builder.Services.AddScoped<IGetByEmail<UsuarioListadoDto>, GetByEmail>();
			builder.Services.AddScoped(typeof(ILogin<Usuario>), typeof(Login));

			// Inyecciones para los Caso de Uso de Auditoria
			builder.Services.AddScoped<IAdd<AuditoriaDto>, AddAuditoria>();

			// Inyecciones para los Caso de Uso de Envio
			builder.Services.AddScoped<IAdd<EnvioDto>, AddEnvio>();
			builder.Services.AddScoped<IGetAll<EnvioListadoDto>, GetAllEnvio>();
			builder.Services.AddScoped<IUpdate<EnvioDto>, UpdateEnvio>();
			builder.Services.AddScoped<IGetByTracking<EnvioListadoDto>, GetByTracking>();

			// Inyecciones para los Caso de Uso de Seguimiento
			builder.Services.AddScoped<IAdd<SeguimientoDto>, AddSeguimiento>();

			// Inyecciones para los Caso de Uso de Agencia
			builder.Services.AddScoped<IGetByName<AgenciaListadoDto>, GetByName>();
			builder.Services.AddScoped<IGetById<AgenciaListadoDto>, LogicaAplicacion.CasoUso.Agencias.GetById>();
			builder.Services.AddScoped<IGetAll<AgenciaListadoDto>, GetAllAgencia>();


			// Inyecciones para los repositorios ERROR:
			builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
			builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
			builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
			builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
			builder.Services.AddScoped<IRepositorioSeguimiento, RepositorioSeguimiento>();
			builder.Services.AddScoped<SeedData>();

			// Inyecciones para auditoría de sesión
			builder.Services.AddHttpContextAccessor();
			builder.Services.AddScoped<ISesionUsuarioActual, SesionUsuarioActual>();

			// Inyecciones para el contexto de la base de datos
			builder.Services.AddDbContext<ObligatorioContext>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			if (app.Environment.IsDevelopment())

				using (var scope = app.Services.CreateScope())
				{
					var services = scope.ServiceProvider;
					//var context = services.GetRequiredService<ObligatorioContext>();

					var seeder = services.GetRequiredService<SeedData>();
					seeder.Run();
				}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseSession();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
