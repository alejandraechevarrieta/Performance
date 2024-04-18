using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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

            context.Routes.MapHttpRoute(
                   name: "AdminPanelPerformanceAppApiAction",
                   routeTemplate: "PerformanceApp/Api/{controller}/{action}"
                   );

            context.Routes.MapHttpRoute(
                    name: "AdminPanelPerformanceAppGApi",
                    routeTemplate: "PerformanceApp/Api/{controller}"
                );
            context.Routes.MapHttpRoute(
                name: "DefaultPerformanceApplApi",
                routeTemplate: "PerformanceApp/Api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            //****************=======Default Route=========*******************


            context.MapRoute(
               "PerformanceApp_default",
               "PerformanceApp/{controller}/{action}/{id}",
               new { action = "Index", id = UrlParameter.Optional }
           );


        }
    }
}