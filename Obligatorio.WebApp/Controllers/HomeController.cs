using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.WebApp.Controllers
{
	public class HomeController : Controller
	{

		private readonly ILoginWebApp<Usuario> _login;

		public HomeController(ILoginWebApp<Usuario> login)
		{
			_login = login;
		}

		public IActionResult Index()
		{
			return View();
		}


		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(UsuarioDto usuario)
		{
			try
			{
				var usuarioLogueado = _login.Execute(usuario.Email, usuario.Password);

				if (!(usuarioLogueado is Empleado))
				{
					ViewBag.Message = "No tiene permisos para ingresar.";
					return View();
				}

				HttpContext.Session.SetString("TipoUsuario", usuarioLogueado.GetType().Name);
				HttpContext.Session.SetString("EmailUsuario", usuarioLogueado.Email.Value);
				HttpContext.Session.SetInt32("IdUsuario", usuarioLogueado.Id);

				if (usuarioLogueado is Administrador)
					return RedirectToAction("Index", "Usuario");

				if (usuarioLogueado is Funcionario)
					return RedirectToAction("Index", "Envio");

				ViewBag.Message = "Error";
				return View();
			}
			catch (Exception ex)
			{
				ViewBag.Message = ex.Message;
				return View();
			}
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Login");
		}
	}
}
