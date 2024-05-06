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

namespace Performance.Areas.PerformanceApp.Controllers.Api
{
    public class PerformanceAppController : ApiController
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public List<PerformanceColaboradorVM> listarColaborador(int idUsuario)
        //{
        //    ServicioPerformance servicio = new ServicioPerformance();
        //    return servicio.listarColaboradores(idUsuario);
        //}
        [System.Web.Http.Route("Api/PerformanceApp/listarColaborador")]
        [System.Web.Http.ActionName("listarColaborador")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage listarColaborador(FormDataCollection form, int? colaborador, int? estado, string idPerfil)
        {
            //List<PerformanceColaboradorVM>


            //var draw = form.Get("draw");
            //var start = form.Get("start");
            //var length = form.Get("length");
            //var sortColumn = (form.Get("columns[" + form.Get("order[0][column]").FirstOrDefault() + "][data]").ToString()).ToString();
            //var sortColumnDir = form.Get("order[0][dir]").ToString();
            //var searchValue = form.Get("search[value]").ToString();
            int pageSize = 25;
            int skip = 1;
            int recordsTotal = 0;

            Servicios.ServicioPerformance servicio = new Servicios.ServicioPerformance();

            var listaPpal = servicio.listarColaboradores(colaborador);

            var listFiltr = listaPpal.Where(x => x.idPerformance > 0).Distinct().ToList();

            recordsTotal = listFiltr.Count();
            var toTake = pageSize;
            if (recordsTotal < pageSize)
            {
                toTake = recordsTotal;
            }

            var lst = listFiltr.Skip(skip).Take(toTake).ToList();
            var lista = lst.ToList();

            var responseData = new { draw = "", recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = lista };

            // Serialize responseData to JSON
            var jsonResult = JsonConvert.SerializeObject(responseData);

            // Create an HttpResponseMessage with the JSON content
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonResult, Encoding.UTF8, "application/json");

            // Return the HttpResponseMessage
            return response;
        }
        [System.Web.Http.Route("Api/PerformanceApp/ListarPerformance")]
        [System.Web.Http.ActionName("ListarPerformance")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage ListarPerformance(DataTableRequestModel requestModel, string idUsuario, string idPerfil, int? colaborador, int? estado, int? lider)
        {
            var draw = requestModel.draw;
            var start = requestModel.start;
            var length = requestModel.length;
            var sortColumn = 1;
            var searchValue = 1;
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            Servicios.ServicioPerformance _servicio = new Servicios.ServicioPerformance();

            // Consulta a tu servicio para obtener los datos
            var listaPpal = _servicio.listarPerformance(idUsuario, idPerfil, colaborador, estado, lider);

            // Filtrar y paginar los datos según los parámetros recibidos
            var listFiltr = listaPpal.Where(x => x.idPerformance > 0).Distinct().ToList();

            recordsTotal = listFiltr.Count();
            var toTake = pageSize;
            if (recordsTotal < pageSize)
            {
                toTake = recordsTotal;
            }

            var lst = listFiltr.Skip(skip).Take(toTake).ToList();
            var lista = lst.ToList();

            var responseData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = lista };

            // Serialize responseData to JSON
            var jsonResult = JsonConvert.SerializeObject(responseData);

            // Create an HttpResponseMessage with the JSON content
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonResult, Encoding.UTF8, "application/json");

            // Return the HttpResponseMessage
            return response;
        }       

        [System.Web.Http.Route("Api/PerformanceApp/listarEstadosPerformance")]
        [System.Web.Http.ActionName("listarEstadosPerformance")]
        [System.Web.Http.HttpGet]
        public List<PerformanceEstados> listarEstadosPerformance()
        {
            Servicios.ServicioPerformance servicio = new Servicios.ServicioPerformance();
            return servicio.listarEstadosPerformance();
        }
        [System.Web.Http.Route("Api/PerformanceApp/GuardarAutoevaluacion")]
        [System.Web.Http.ActionName("GuardarAutoevaluacion")]
        [System.Web.Http.HttpPost]
        public async Task<int> GuardarAutoevaluacion(PerformanceAutoevaluacionVM autoevaluacion)
        {
            try
            {
                Servicios.ServicioPerformance _servicio = new Servicios.ServicioPerformance();

                var tmp = _servicio.GuardarAutoevaluacion(autoevaluacion);

                return tmp;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
       
        [System.Web.Http.Route("Api/PerformanceApp/GenerarAltasPerformance")]
        [System.Web.Http.ActionName("GenerarAltasPerformance")]
        [System.Web.Http.HttpGet]
       public async Task<int> GenerarAltasPerformance()
        {
            string API_BASE_URL = ConfigurationSettings.AppSettings["urlBuho"];
            string endpoint = $"Ingenieria/api/Login/DatosColaboradores";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(API_BASE_URL + endpoint);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserializa la respuesta JSON directamente a una lista de objetos ColaboradorVM
                    List<ColaboradorVM> colaboradores = JsonConvert.DeserializeObject<List<ColaboradorVM>>(responseBody);

                    Servicios.ServicioPerformance _servicio = new Servicios.ServicioPerformance();
                    var tmp = _servicio.GenerarAltasPerformance(colaboradores.ToList());

                    return tmp;
                }
                catch (JsonSerializationException ex)
                {
                    Console.WriteLine("Error al deserializar la respuesta JSON:");
                    Console.WriteLine(ex.Message);
                    throw;                    
                }
            }
        }
        [System.Web.Http.Route("Api/PerformanceApp/BuscarDatosUsuario")]
        [System.Web.Http.ActionName("BuscarDatosUsuario")]
        [System.Web.Http.HttpGet]
        public async Task<ColaboradorVM> BuscarDatosUsuario(int idUsuario)
        {
            string API_BASE_URL = ConfigurationSettings.AppSettings["urlBuho"];
            string endpoint = $"Ingenieria/api/Login/DatosUsuario?idUsuario=" + idUsuario;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(API_BASE_URL + endpoint);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserializa la respuesta JSON directamente a una lista de objetos ColaboradorVM
                    ColaboradorVM colaborador = JsonConvert.DeserializeObject<ColaboradorVM>(responseBody);
                    return colaborador;
                }
                catch (JsonSerializationException ex)
                {
                    Console.WriteLine("Error al deserializar la respuesta JSON:");
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public class DataTableRequestModel
        {
            public int draw { get; set; }
            public int start { get; set; }
            public int length { get; set; }
            public int? colaborador { get; set; }
            public int? estado { get; set; }
            public int idPerfil { get; set; }
        }

    }
}
