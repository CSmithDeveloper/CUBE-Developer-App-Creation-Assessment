// <copyright file="SwaggerConfig.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CubeGlobal.TemperatureConverter.WebAPI.SwaggerConfig), "Register")]

namespace CubeGlobal.TemperatureConverter.WebAPI
{
    using System.Web.Hosting;
    using System.Web.Http;
    using Swashbuckle.Application;

    /// <summary>
    /// Configures Swagger.
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Registers this instance.
        /// </summary>
        public static void Register()
        {
            const string ServiceName = "Temperature Converter Web API";

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", ServiceName);
                    c.PrettyPrint();
                    c.IncludeXmlComments(HostingEnvironment.MapPath("~/bin/CubeGlobal.TemperatureConverter.WebAPI.xml"));                    
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle(ServiceName);
                });
        }
    }
}