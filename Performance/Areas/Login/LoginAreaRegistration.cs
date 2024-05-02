using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Performance.Areas.Login
{
    public class LoginAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Login";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.Routes.MapHttpRoute(
                   name: "AdminPanelLoginApiAction",
                   routeTemplate: "Login/Api/{controller}/{action}"
                   );

            context.Routes.MapHttpRoute(
                    name: "AdminPanelLoginApi",
                    routeTemplate: "Login/Api/{controller}"
                );
            context.Routes.MapHttpRoute(
                name: "DefaultLoginApi",
                routeTemplate: "Login/Api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            //****************=======Default Route=========*******************


            context.MapRoute(
               "Login_default",
               "Login/{controller}/{action}/{id}",
               new { action = "Index", id = UrlParameter.Optional }
           );


        }
    }
}