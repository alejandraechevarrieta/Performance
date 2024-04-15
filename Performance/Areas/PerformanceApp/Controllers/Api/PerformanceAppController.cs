using Performance.Model;
using Performance.Servicios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Performance.Areas.PerformanceApp.Controllers.Api
{
    public class PerformanceAppController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public List<PerformanceColaboradorVM> listarColaborador(int idUsuario)
        {
            ServicioPerformance servicio = new ServicioPerformance();
            return servicio.listarColaboradores(idUsuario);
        }

    }
}
