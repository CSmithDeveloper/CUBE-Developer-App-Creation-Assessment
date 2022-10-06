// <copyright file="Global.asax.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.UI
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    /// <summary>
    /// Responds to application level events raised by ASP.NET or by HttpModules.
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}