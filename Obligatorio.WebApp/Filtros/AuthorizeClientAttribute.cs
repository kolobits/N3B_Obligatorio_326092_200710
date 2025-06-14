using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filtros
{
	public class AuthorizeClientAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var session = context.HttpContext.Session;
			var tipoUsuario = session.GetString("TipoUsuario");

			if (string.IsNullOrEmpty(tipoUsuario) || tipoUsuario != "Cliente")
			{
				context.Result = new RedirectToActionResult("Login", "Home", null);
			}

			base.OnActionExecuting(context);
		}
	}
}
