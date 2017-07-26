using log4net;
using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CardProHost {
    public class WebApiApplication : System.Web.HttpApplication {
        private readonly ILog logger = LogManager.GetLogger(typeof(WebApiApplication));

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            new AppHost().Init();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Log4Net
            GlobalContext.Properties["AppFolder"] = ConfigurationManager.AppSettings["AppFolder"];
            GlobalContext.Properties["AppName"] = ConfigurationManager.AppSettings["AppName"];
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(ConfigurationManager.AppSettings["Log4NetConfigurationPath"]));

            logger.Info($"started application {ConfigurationManager.AppSettings["AppName"]} at {DateTime.Now}");
        }
    }
}
