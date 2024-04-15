using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Performance.Areas.PerformanceApp
{
    public class PerformanceAppAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PerformanceApp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PerformanceApp_default",
                "PerformanceApp/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
           
        }
    }
}