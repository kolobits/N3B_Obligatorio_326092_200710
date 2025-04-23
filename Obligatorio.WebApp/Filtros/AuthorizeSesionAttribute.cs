using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filtros
{
	public class AuthorizeSesionAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var session = context.HttpContext.Session;
			var email = session.GetString("EmailUsuario");

			if (string.IsNullOrEmpty(email))
			{
				context.Result = new RedirectToActionResult("Login", "Home", null);
			}

			base.OnActionExecuting(context);
		}
	}
}
