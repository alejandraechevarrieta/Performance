using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Performance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormularioB()
        {
            return View("FormularioB");
        }

        public ActionResult Dashboard()
        {
            return View("Dashboard");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

    }
}