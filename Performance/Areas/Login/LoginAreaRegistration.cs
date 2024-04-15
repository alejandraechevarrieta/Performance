using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            context.MapRoute(
                "Login_default",
                "Login/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}