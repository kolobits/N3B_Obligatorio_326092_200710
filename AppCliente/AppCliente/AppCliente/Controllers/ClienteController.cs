using System.Text.Json;
using AppCliente.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using RestSharp;


namespace AppCliente.Controllers
{
	public class ClienteController : Controller
	{
		public IActionResult CambiarPassword()
		{
			return View(new CambioPasswordDto());
		}



		[HttpPost]
		public IActionResult CambiarPassword(CambioPasswordDto cambioPassword)
		{
			try
			{
                var token = HttpContext.Session.GetString("token");  // Suponiendo que el token está almacenado en la sesión

                if (string.IsNullOrEmpty(token))
                {
                    throw new Exception("No se encontró un token válido para autenticar la solicitud.");
                }
                var idUsuario = HttpContext.Session.GetInt32("id");
				if (idUsuario == null)
					throw new Exception("Sesión expirada. Iniciá sesión nuevamente.");

				var options = new RestClientOptions("https://localhost:7018")
				{
					MaxTimeout = -1,
				};
				var client = new RestClient(options);
				var request = new RestRequest($"/api/Clientes/cambiar-password/{idUsuario}", Method.Put);
                request.AddHeader("Authorization", "Bearer " + token);
                var body = JsonSerializer.Serialize(cambioPassword);
				request.AddStringBody(body, DataFormat.Json);
				RestResponse response = client.Execute(request);
				if ((int)response.StatusCode == 404)
				{
					throw new Exception("Problemas con las credenciales");
				}
				if ((int)response.StatusCode == 200)
				{
					ViewBag.mensaje = "Contraseña cambiada correctamente";
					return View(new CambioPasswordDto());
				}
			}
			catch (Exception e)
			{
				ViewBag.mensaje = "Ocurrió un error: " + e.Message;
			}

			return View("CambiarPassword");
		}
	}
}


