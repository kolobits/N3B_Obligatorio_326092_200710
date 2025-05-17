
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

namespace Obligatorio.WebApi
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


			// Inyecciones para los repositorios ERROR:
			builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
			builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
			builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
			builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
			builder.Services.AddScoped<IRepositorioSeguimiento, RepositorioSeguimiento>();
			builder.Services.AddScoped<SeedData>();

			// Inyecciones para auditor�a de sesi�n
			builder.Services.AddHttpContextAccessor();
			builder.Services.AddScoped<ISesionUsuarioActual, SesionUsuarioActual>();

			// Inyecciones para el contexto de la base de datos
			builder.Services.AddDbContext<ObligatorioContext>();


			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
