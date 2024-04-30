using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Performance.Areas.PerformanceApp.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index(string perfil, string idUsuario)
        {            
            System.Web.HttpContext.Current.Session["perfil"] = perfil;
            System.Web.HttpContext.Current.Session["idUsuario"] = idUsuario;
            return View();
        }
        public ActionResult Crud(string view, int idPerformance)
        {
            ViewBag.View = view;
            ViewBag.IdPerformance = idPerformance;

            return View();
        }


    }
}