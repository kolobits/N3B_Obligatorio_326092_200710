using System.Text.Json;
using AppCliente.Models;
using AppCliente.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace AppCliente.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(UsuarioLoginDto user)
		{
			try
			{
				var options = new RestClientOptions("https://localhost:7018")
				{
					MaxTimeout = -1,
				};
				var client = new RestClient(options);
				var request = new RestRequest("/api/Auth/login", Method.Post);
				var body = JsonSerializer.Serialize(user);
				request.AddStringBody(body, DataFormat.Json);
				RestResponse response = client.Execute(request);
				if ((int)response.StatusCode == 404)
				{
					throw new Exception("Problemas con las credenciales");
				}
				var optionsJson = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				};
				UsuarioListadoDto unUsuario = JsonSerializer.Deserialize<UsuarioListadoDto>(response.Content, optionsJson);
				if (unUsuario == null)
				{
					throw new Exception("no se encontro el usuario");
				}

				string token = GetToken(user);
				HttpContext.Session.SetInt32("id", unUsuario.Id);
				HttpContext.Session.SetString("token", token);

				return RedirectToAction("Index", "Envio");

			}
			catch (Exception e)
			{
				ViewBag.mensaje = e.Message;
			}
			return View("Index");
		}

		private string GetToken(UsuarioLoginDto user)
		{
			var options = new RestClientOptions("https://localhost:7018")
			{
				MaxTimeout = -1,
			};
			var client = new RestClient(options);
			var request = new RestRequest("/api/Auth/login", Method.Post);
			request.AddHeader("Content-Type", "application/json");
			var body = JsonSerializer.Serialize(user);
			request.AddStringBody(body, DataFormat.Json);
			RestResponse response = client.Execute(request);

			if ((int)response.StatusCode != 200)
			{
				throw new Exception("Problemas al generar el token");
			}
			var optionsJson = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};
			TokenResponse tokenResponse = JsonSerializer.Deserialize<TokenResponse>(response.Content, optionsJson);
			return tokenResponse.Token;
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("index");
		}

	}
}

