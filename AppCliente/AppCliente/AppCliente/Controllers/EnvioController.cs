using AppCliente.Models.Envio;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace AppCliente.Controllers
{
    public class EnvioController : Controller
    {
        public IActionResult Index(string message)
        {
            try
            {
                var options = new RestClientOptions("https://localhost:7018")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/Envios/cliente/4", Method.Get);
                request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuYS5nb256YWxlekBnbWFpbC5jb20iLCJuYmYiOjE3NTAzNDc2MjAsImV4cCI6MTc1MDM1MTIxOSwiaWF0IjoxNzUwMzQ3NjIwLCJpc3MiOiJPYmxpZ2F0b3Jpb0FQSSIsImF1ZCI6IkNsaWVudGVzQWdlbmNpYSJ9.3L3nP5D0sm7_vyhi26VZdaNQJ626bkja--s-g2tvWlY");
                RestResponse response = client.Execute(request);
                if ((int)response.StatusCode == 404)
                {
                    throw new Exception("Problemas con las credenciales");
                }
                var optionsJson = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                List<EnvioListadoDto> envios = JsonSerializer.Deserialize<List<EnvioListadoDto>>(response.Content, optionsJson);
                ViewBag.Message = message;
                return View(envios);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
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
    }
}
