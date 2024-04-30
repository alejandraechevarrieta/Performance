using Performance.Model;
using Performance.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Web.Hosting;
using System.Net.Http.Headers;
using System.Web.Services.Description;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace Performance.Areas.Login.Controllers.Api
{
    public class LoginController : ApiController
    {
        [System.Web.Http.Route("Api/Login/ValidarIngreso")]
        [System.Web.Http.ActionName("ValidarIngreso")]
        [System.Web.Http.HttpGet]
        public async Task<int> ValidarIngreso(string usuario, string password)
        {
            string API_BASE_URL = ConfigurationSettings.AppSettings["urlBuho"];
            string endpoint = $"Ingenieria/api/Login/GetUsuario?usuario={usuario}&password={password}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(API_BASE_URL + endpoint);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (int.TryParse(responseBody, out int result)) //verifica que sea un numero
                    {

                        return result;
                    }
                    else
                    {
                        JObject jsonResponse = JObject.Parse(responseBody); //es un objeto

                        if (jsonResponse["Error"] != null)  //toma el valor del numero 
                        {
                            int error = (int)jsonResponse["Error"];
                            return error;
                        }
                        else
                        {
                            Console.WriteLine("La respuesta no contiene un formato válido.");
                            return 0;
                        }
                    }
                }
                catch (JsonReaderException ex)
                {
                    Console.WriteLine("Error al leer la respuesta JSON:");
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("Error al realizar la solicitud HTTP:");
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        [System.Web.Http.Route("api/Login/GetPerfiles")]
        [System.Web.Http.ActionName("GetPerfiles")]
        [System.Web.Http.HttpGet]
        public async Task<int> GetPerfiles(int idUsuario)
        {
            string API_BASE_URL = ConfigurationSettings.AppSettings["urlBuho"];
            string endpoint = $"Ingenieria/api/Login/GetPerfiles?idUsuario={idUsuario}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(API_BASE_URL + endpoint);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Verificar si la respuesta no está vacía
                    if (!string.IsNullOrEmpty(responseBody))
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);
                        var perfil = 0;
                        List<int> valores = new List<int>();

                        foreach (var item in jsonResponse)
                        {
                            int valor;
                            if (int.TryParse(item.Value.ToString(), out valor))
                            {
                                valores.Add(valor);
                            }
                        }
                        //asigno perfil 
                        foreach (var valor in valores)
                        {
                            if (valor == 127 || valor == 128 || valor == 129)
                            {
                                perfil = valor;
                            }
                        }

                        return perfil;
                    }
                    else
                    {
                        Console.WriteLine("La respuesta JSON está vacía.");
                        // Retornar una lista vacía en caso de que la respuesta esté vacía
                        return 0;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("Error al realizar la solicitud HTTP:");
                    Console.WriteLine(ex.Message);
                    throw;
                    return 0;
                }
                catch (JsonSerializationException ex)
                {
                    Console.WriteLine("Error al deserializar la respuesta JSON:");
                    Console.WriteLine(ex.Message);
                    throw;
                    return 0;
                }

            }
        }

    }
}
