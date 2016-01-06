using datebook.App_Start;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace datebook
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var languageCookie = HttpContext.Current.Request.Cookies["chosenLanguage"];
            var userLanguages = HttpContext.Current.Request.UserLanguages;
            var cultureInfo = new CultureInfo(languageCookie != null
                ? languageCookie.Value
                : userLanguages != null
                ? userLanguages[0]
                : "en"
            );
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }
    }
}
