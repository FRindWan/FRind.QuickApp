using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using QuickApp.Mvc;
using QuickApp.Config;
using System.Reflection;
using QuickApp.Data.Extensions;
using QuickApp.Data.Infrastructure;

namespace QuickApp.NoteExample.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IQuickApp app = ConfigSource.Instance
                .RegisterMvc(Assembly.GetExecutingAssembly())
                .UseQuickAppData()
                .AddCommandScanAssembly(Assembly.Load("QuickApp.NoteExample.Application"))
                .AddDependInitialize(new NoteExampleDependencyInitialize())
                .SetDbInfo(typeof(SqlDbContext), typeof(MSSqlDbContext), QuickApp.Infrastructure.DataBaseType.MSSQLSERVER)
                .Initialize();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
