using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Performance.Areas.PerformanceApp.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crud()
        {
            return View();
        }
    }
}