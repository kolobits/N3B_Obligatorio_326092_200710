//using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
//using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
//using Obligatorio.LogicaAccesoDatos.Lista;
//using Obligatorio.LogicaAplicacion.CasoUso.Usuarios;
//using Obligatorio.LogicaNegocio.InterfacesRepositorios;

//namespace Obligatorio.WebApp
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.
//            builder.Services.AddControllersWithViews();
//            builder.Services.AddSession();

//            // Inyecciones para los Caso de Uso de Usuario
//            //builder.Services.AddScoped<IAddUsuario<UsuarioDto>, AddUsuario>();
//            //builder.Services.AddScoped<IGetAll<UsuarioListadoDto>, GetAllUsuario>();
//            //builder.Services.AddScoped<IGetById<UsuarioListadoDto>, GetById>();  
//            //builder.Services.AddScoped<IRemove, RemoveUsuario>();

//            // Inyecciones para los repositorios ERROR:
//            //builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();


//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();


//            app.UseRouting();
//            app.UseSession();

//            app.UseAuthorization();

//            app.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Home}/{action=Index}/{id?}");

//            app.Run();
//        }
//    }
//}
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAccesoDatos.Lista;
using Obligatorio.LogicaAplicacion.CasoUso.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

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


			//            // Inyecciones para los Caso de Uso de Usuario
			builder.Services.AddScoped<IAddUsuario<UsuarioDto>, AddUsuario>();
			builder.Services.AddScoped<IGetAll<UsuarioListadoDto>, GetAllUsuario>();
			builder.Services.AddScoped<IGetById<UsuarioListadoDto>, GetById>();
			builder.Services.AddScoped<IRemove, RemoveUsuario>();

			//            // Inyecciones para los repositorios ERROR:
			builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
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
