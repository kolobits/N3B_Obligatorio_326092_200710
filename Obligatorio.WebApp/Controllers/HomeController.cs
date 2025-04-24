using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
	public class HomeController : Controller
	{

		private readonly ILogin _login;

		public HomeController(ILogin login)
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
		public IActionResult Login(VMUsuario model)
		{
			try
			{
				var usuario = _login.Execute(model.Email, model.Password);

				if (usuario == null)
				{
					ViewBag.Message = "Las credenciales no son válidas.";
					return View(model);
				}

				if (!(usuario is Empleado))
				{
					ViewBag.Message = "No tiene permisos para ingresar.";
					return View(model);
				}

				HttpContext.Session.SetString("TipoUsuario", usuario.GetType().Name);
				HttpContext.Session.SetString("EmailUsuario", usuario.Email.Value);
				HttpContext.Session.SetInt32("IdUsuario", usuario.Id);

				if (usuario is Administrador)
					return RedirectToAction("Index", "Usuario");

				if (usuario is Funcionario)
					return RedirectToAction("Index", "Envio");

				ViewBag.Message = "Rol no reconocido.";
				return View(model);
			}
			catch (Exception ex)
			{
				ViewBag.Message = ex.Message;
				return View(model);
			}
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Login");
		}

		public IActionResult Privacy()
		{
			return View();
		}
	}
}
