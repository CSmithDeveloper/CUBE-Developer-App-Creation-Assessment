// <copyright file="RouteConfig.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.UI
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Configures the application's routes.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}