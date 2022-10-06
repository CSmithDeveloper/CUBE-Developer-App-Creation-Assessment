// <copyright file="Global.asax.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.WebAPI
{
    using System.Web;
    using System.Web.Http;

    /// <summary>
    /// Responds to application level events raised by ASP.NET or by HttpModules.
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        protected void Application_Start()
        {            
            GlobalConfiguration.Configure(WebApiConfig.Register);   
        }
    }
}