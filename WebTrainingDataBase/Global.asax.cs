using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebTrainingDataBase.Infrestructura;

namespace WebTrainingDataBase
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var owinStartup = typeof(WebTrainingDataBase.App_Start.Startup);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebProfile.Run();
            System.Web.Optimization.BundleTable.EnableOptimizations = true;
            System.Web.Helpers.AntiForgeryConfig.UniqueClaimTypeIdentifier = System.Security.Claims.ClaimTypes.NameIdentifier;
        }
    }
}
