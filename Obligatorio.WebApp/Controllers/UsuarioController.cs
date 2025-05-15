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
			catch (EmailRepetidoException)
			{
				ViewBag.Message = $"El mail {usuario.Email} ya está registrado";
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

		[AuthorizeAdministrador]
		public IActionResult Delete(int id)
		{
			_remove.Execute(id);
			return RedirectToAction("index");
		}

		[AuthorizeAdministrador]
		public IActionResult Edit(int id)
		{
			try
			{
				UsuarioListadoDto unU = _getById.Execute(id);
				UsuarioDto usuario = new UsuarioDto(unU.Nombre, unU.Apellido, unU.Email, "passss12+.");
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
		public IActionResult Edit(int id, UsuarioDto usuario)
		{
			try
			{
				_update.Execute(id, usuario);
				return RedirectToAction("Index", new { message = "Modificacion exitosa" });
			}
			catch (Exception e)
			{
				return RedirectToAction("Index", new { message = e.Message });
			}
		}
	}
}
