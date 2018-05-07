using Student.Business.Facade.App_Start;
using Student.Business.Facade.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Student.Business.Facade
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Filters.Add(new ConnectionFilter());
            log4net.Config.XmlConfigurator.Configure();
            AutofacConfigure.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
