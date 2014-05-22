using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Grodslok.TvSeriesManager {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            new AppHost().Init();
        }

        protected void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("api/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" }); 
        }
        
    }
}
