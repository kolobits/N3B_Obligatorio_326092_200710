using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.WebApp.Filtros;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
	[AuthorizeSesion]
	public class UsuarioController : Controller
	{

		IGetAll<UsuarioListadoDto> _getAll;
		IAdd<UsuarioDto> _add;
		IRemove _remove;
		IGetById<UsuarioListadoDto> _getById;
		IUpdate<UsuarioDto> _update;

		public UsuarioController(IGetAll<UsuarioListadoDto> getAll,
								 IAdd<UsuarioDto> add,
								 IRemove remove,
								 IGetById<UsuarioListadoDto> getById,
								 IUpdate<UsuarioDto> update)
		{
			_getAll = getAll;
			_add = add;
			_remove = remove;
			_getById = getById;
			_update = update;

		}


		public IActionResult Index()
		{
			return View(_getAll.Execute());
		}


		[AuthorizeAdministrador]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[AuthorizeAdministrador]
		public IActionResult Create(VMUsuario usuario)
		{
			try
			{
				_add.Execute(new UsuarioDto(
											usuario.Nombre,
											usuario.Apellido,
											usuario.Email,
											usuario.Password
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
			catch (EmailRepetidoException e)
			{
				ViewBag.Message = e.Message;
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

        public IActionResult Details(int id)
        {
            UsuarioListadoDto unU = _getById.Execute(id);
            if (unU == null)
            {
                return RedirectToAction("index");
            }
            return View(unU);
        }

        [AuthorizeAdministrador]
		public IActionResult Delete(int id)
		{
			_remove.Execute(id);
			return RedirectToAction("index");
		}

    
        [AuthorizeAdministrador]
		public IActionResult Update(int id)
		{
			try
			{
				UsuarioListadoDto unU = _getById.Execute(id);
				var usuario = new VMUsuario { Nombre = unU.Nombre, Apellido = unU.Apellido, Email = unU.Email, Password = "" };
				ViewBag.Id = id;
				return View(usuario);
			}
			catch (Exception e)
			{
				return RedirectToAction("Index", new { message = e.Message });
			}
		}

		[HttpPost]
		[AuthorizeAdministrador]
		public IActionResult Update(int id, VMUsuario usuario)
		{
			try
			{
                var Usuariodto = new UsuarioDto(usuario.Nombre, usuario.Apellido, usuario.Email, usuario.Password);
                _update.Execute(id, Usuariodto);
				return RedirectToAction("Index", new { message = "Modificacion exitosa" });
			}
            catch (EmailRepetidoException e)
            {
                ViewBag.Message = e.Message;
            }
            catch (Exception e)
			{
				return RedirectToAction("Index", new { message = e.Message });
			}
            return View();
        }
	}
}
