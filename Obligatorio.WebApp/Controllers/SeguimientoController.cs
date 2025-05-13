using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Seguimientos;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaAplicacion.CasoUso.Seguimiento;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.WebApp.Controllers;
using Obligatorio.WebApp.Filtros;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
    public class SeguimientoController : Controller
    {
        IAdd<SeguimientoDto> _add;

        public SeguimientoController(IAdd<SeguimientoDto> add)
        {
            _add = add;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AuthorizeSesion]
        public IActionResult Create(int envioId)
        {
            return View(new VMSeguimiento { EnvioId = envioId });
        }


        [HttpPost]
        public IActionResult Create(VMSeguimiento seguimiento)
        {
            try 
            {
                _add.Execute(new SeguimientoDto(seguimiento.Comentario,
                                               seguimiento.Fecha,
                                               seguimiento.EnvioId));
                return RedirectToAction("index","Envio");
            }
            catch (Exception e)
            {
                ViewBag.Message = "Hubo un error";
            }
            return View();
        }

    }
}

