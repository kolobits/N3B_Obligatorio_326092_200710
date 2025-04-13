using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.WebApp.Models;
using System.Diagnostics;

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

                if (usuario != null)
                {
                    
                    HttpContext.Session.SetString("TipoUsuario", usuario.GetType().Name);
                    HttpContext.Session.SetString("EmailUsuario", usuario.Email.Value);
                    HttpContext.Session.SetInt32("IdUsuario", usuario.Id);

                    return RedirectToAction("Index", "Home");
                }
            
                else
                {
                    ViewBag.Message = "Las credenciales no son válidas";
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message; 
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
