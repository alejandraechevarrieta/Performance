using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Performance.Areas.Login.Controllers.Api
{
    public class LoginController : Controller
    {
        [HttpGet]
        [ActionName("ValidarIngreso")]
        public int? ValidarIngreso(int idUsuario)
        {
            try
            {
                Performance.Servicios.ServicioLogin _servicio = new Performance.Servicios.ServicioLogin();
                var tmp = _servicio.ValidarIngreso(idUsuario);
                System.Web.HttpContext.Current.Session["idPerfil"] = tmp;
                return 118;
               
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
