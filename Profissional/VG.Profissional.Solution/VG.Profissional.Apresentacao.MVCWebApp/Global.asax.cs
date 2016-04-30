using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VG.Profissional.Aplicacao.AutoMapper;
using VG.Profissional.Apresentacao.MVCWebApp.App_Start;

namespace VG.Profissional.Apresentacao.MVCWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            SimpleInjectorInitializer.Initialize();

            BundleTable.EnableOptimizations = true;
        }
    }
}
