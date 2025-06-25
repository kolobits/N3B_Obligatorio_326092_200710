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

        public IActionResult ListarEnviosPorFecha(DateTime? fechaCreacion, DateTime? fechaFinalizacion, string estado)
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

                string fechaCreacionStr = fechaCreacion?.ToString("yyyy-MM-dd");
                string fechaFinalizacionStr = fechaFinalizacion?.ToString("yyyy-MM-dd");

                var options = new RestClientOptions("https://localhost:7018")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest($"/api/Envios/listar-enviosFecha/{idCliente}?fechaCreacion={fechaCreacionStr}&fechaFinalizacion={fechaFinalizacionStr}&estado={estado}", Method.Get);
                request.AddHeader("Authorization", $"Bearer {token}");

                // Ejecutar la solicitud
                RestResponse response = client.Execute(request);

                // Validar la respuesta
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

                // Deserializar los envíos
                List<EnvioListadoDto> envios = JsonSerializer.Deserialize<List<EnvioListadoDto>>(response.Content, optionsJson);

                // Devolver la vista con los envíos
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

