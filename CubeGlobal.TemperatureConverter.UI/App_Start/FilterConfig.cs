// <copyright file="FilterConfig.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.UI
{
    using System.Web.Mvc;

    /// <summary>
    /// Configures the application's filters.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}