using System.Text.Json;
using AppCliente.Models.Envio;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace AppCliente.Controllers
{
	public class EnvioController : Controller
	{
		public IActionResult Index(string message)
		{
			try
			{
				var token = HttpContext.Session.GetString("token");
				if (string.IsNullOrEmpty(token))
				{
					throw new Exception("No se encontró un token válido para autenticar la solicitud.");
				}
				var idCliente = HttpContext.Session.GetInt32("id");
				if (idCliente == null)
					throw new Exception("Sesión expirada. Iniciá sesión nuevamente.");

				var options = new RestClientOptions("https://localhost:7018")
				{
					MaxTimeout = -1,
				};
				var client = new RestClient(options);
				var request = new RestRequest($"/api/Envios/listar-envios/{idCliente}", Method.Get);
				request.AddHeader("Authorization", $"Bearer {token}");

				RestResponse response = client.Execute(request);

				if ((int)response.StatusCode == 401)
					throw new Exception("No autorizado. Iniciá sesión nuevamente.");
				if ((int)response.StatusCode == 204)
					throw new Exception("No hay envíos registrados.");
				if ((int)response.StatusCode != 200)
					throw new Exception("Error al obtener los envíos.");

				var optionsJson = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				};

				List<EnvioListadoDto> envios = JsonSerializer.Deserialize<List<EnvioListadoDto>>(response.Content, optionsJson);
				return View(envios);
			}
			catch (Exception e)
			{
				ViewBag.Message = e.Message;
				return View(new List<EnvioListadoDto>());
			}
		}



		public IActionResult GetEnviosTracking()
		{
			return View("Detalles");
		}


		public IActionResult BuscarPorTracking(string tracking)
		{
			try
			{
				var options = new RestClientOptions("https://localhost:7018")
				{
					MaxTimeout = -1,
				};
				var client = new RestClient(options);
				var request = new RestRequest($"/api/Envios/{tracking}", Method.Get);
				RestResponse response = client.Execute(request);
				if ((int)response.StatusCode == 404)
				{
					throw new Exception("No se econtro el envío");

				}
				var optionsJson = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				};
				var envio = JsonSerializer.Deserialize<EnvioListadoDto>(response.Content, optionsJson);
				return View("Detalles", envio);
			}
			catch (Exception e)
			{
				ViewBag.Message = e.Message;
				return View("Detalles");


			}
		}


		public IActionResult VerSeguimientos(int envioId)
		{
			try
			{
				var token = HttpContext.Session.GetString("token");
				if (string.IsNullOrEmpty(token))
					throw new Exception("Sesión expirada.");

				var client = new RestClient("https://localhost:7018");
				var request = new RestRequest($"/api/envios/seguimientos/{envioId}", Method.Get);
				request.AddHeader("Authorization", $"Bearer {token}");

				var response = client.Execute(request);

				if ((int)response.StatusCode == 404)
					throw new Exception("No se encontraron seguimientos.");

				var optionsJson = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
				var seguimientos = JsonSerializer.Deserialize<List<SeguimientoDto>>(response.Content, optionsJson);

				return View("VerSeguimientos", seguimientos);
			}
			catch (Exception e)
			{
				ViewBag.Message = e.Message;
				return View("VerSeguimientos", new List<SeguimientoDto>());
			}
		}

		public IActionResult ListarPorFecha(DateTime? fechaInicio, DateTime? fechaFin, string estado)
		{
			try
			{
				var token = HttpContext.Session.GetString("token");
				if (string.IsNullOrEmpty(token))
				{
					throw new Exception("No se encontró un token válido para autenticar la solicitud.");
				}

				var idCliente = HttpContext.Session.GetInt32("id");
				if (idCliente == null)
					throw new Exception("Sesión expirada. Iniciá sesión nuevamente.");

				string fechaInicioStr = fechaInicio?.ToString("yyyy-MM-dd");
				string fechaFinStr = fechaFin?.ToString("yyyy-MM-dd");
                estado = estado ?? string.Empty;

                var options = new RestClientOptions("https://localhost:7018")
				{
					MaxTimeout = -1,
				};
				var client = new RestClient(options);
				var request = new RestRequest($"/api/Envios/listar-enviosFecha/{idCliente}?fechaInicio={fechaInicioStr}&fechaFin={fechaFinStr}&estado={estado}", Method.Get);
				request.AddHeader("Authorization", $"Bearer {token}");


				RestResponse response = client.Execute(request);

				if ((int)response.StatusCode == 401)
					throw new Exception("No autorizado. Iniciá sesión nuevamente.");
				if ((int)response.StatusCode == 204)
					throw new Exception("No hay envíos registrados.");
				if ((int)response.StatusCode != 200)
					throw new Exception("Error al obtener los envíos.");

				var optionsJson = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				};

				List<EnvioListadoDto> envios = JsonSerializer.Deserialize<List<EnvioListadoDto>>(response.Content, optionsJson);

				return View("Index", envios);
			}
			catch (Exception e)
			{
				ViewBag.Message = e.Message;
				return View("Index", new List<EnvioListadoDto>());
			}
		}

		public IActionResult ListarPorComentario(string comentario)
		{
			try
			{
				var token = HttpContext.Session.GetString("token");
				if (string.IsNullOrEmpty(token))
					throw new Exception("No se encontró un token válido para autenticar la solicitud.");

				var idCliente = HttpContext.Session.GetInt32("id");
				if (idCliente == null)
					throw new Exception("Sesión expirada. Iniciá sesión nuevamente.");

				var options = new RestClientOptions("https://localhost:7018")
				{
					MaxTimeout = -1,
				};
				var client = new RestClient(options);

				var comentarioEncoded = System.Net.WebUtility.UrlEncode(comentario);
				var request = new RestRequest($"/api/Envios/listar-enviosComentario/{idCliente}?comentario={comentarioEncoded}", Method.Get);
				request.AddHeader("Authorization", $"Bearer {token}");

				RestResponse response = client.Execute(request);

				if ((int)response.StatusCode == 401)
					throw new Exception("No autorizado. Iniciá sesión nuevamente.");
				if ((int)response.StatusCode == 204)
					throw new Exception("No hay envíos registrados con ese comentario.");
				if ((int)response.StatusCode != 200)
					throw new Exception("Error al obtener los envíos.");

				var optionsJson = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				};

				List<EnvioListadoDto> envios = JsonSerializer.Deserialize<List<EnvioListadoDto>>(response.Content, optionsJson);
				return View("Index", envios);
			}
			catch (Exception e)
			{
				ViewBag.Message = e.Message;
                return View("Index", new List<EnvioListadoDto>());
            }
		}
	}
}

