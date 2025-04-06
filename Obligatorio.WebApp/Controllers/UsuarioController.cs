using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
    public class UsuarioController : Controller
    {

        IGetAll<UsuarioListadoDto> _getAll;
        IAddUsuario<UsuarioDto> _add;
        IRemove _remove;
        IGetById<UsuarioListadoDto> _getById;

        public UsuarioController(IGetAll<UsuarioListadoDto> getAll,
                                 IAddUsuario<UsuarioDto> add,
                                 IRemove remove,
                                 IGetById<UsuarioListadoDto> getById)
        {
            _getAll = getAll;
            _add = add;
            _remove = remove;
            _getById = getById;
        }


        public IActionResult Index()
        {
            return View(_getAll.Execute());
        }

       

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            UsuarioListadoDto unU = _getById.Execute(id);
            if (unU == null)
            {
                return RedirectToAction("index");
            }
            return View(unU);
        }

        [HttpPost]
        public IActionResult Create(VMUsuario usuario)
        {
            try
            {
                _add.Execute(new UsuarioDto(usuario.Id,
                                            usuario.Nombre.Value,
                                            usuario.Apellido,
                                            usuario.Email.Value,
                                            usuario.Password.Value
                                                ));
                return RedirectToAction("index");
            }
            catch (NombreException)
            {
                ViewBag.Message = "El nombre ingresado no es correcto";
            }
            catch (EmailException)
            {
                ViewBag.Message = "El email ingresado no es correcto";
            }
            catch (EmailRepetidoException)
            {
                ViewBag.Message = $"El mail {usuario.Email.Value} esta repetido";
            }
            catch (ArgumentNullException)
            {
                ViewBag.Message = "No envio datos";
            }
            catch (Exception)
            {
                ViewBag.Message = "Hubo un error";
            }
            return View();

        }

        public IActionResult Delete(int id)
        {
            _remove.Execute(id);
            return RedirectToAction("index");
        }

    }
}
