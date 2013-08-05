using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Nova.Framework.IoCContainer;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Nova.Applications.Web.Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            RegisterAllTypes();
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(null)); // TODO: Pass in a valid container when created
        }

        // register all types in the Nova solution
        private void RegisterAllTypes()
        {
            IList<string> assemblies = new List<string> 
            { 
                "Nova.Applications.Web.Mvc.dll", 
                "Nova.Core.dll"
            };

            string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", string.Empty);
            IEnumerable<string> assemblyPaths = assemblies.Select(p => Path.Combine(assemblyDir, p));

            TypeContainer.RegisterTypesForApplication(assemblyPaths);
        }
    }
}