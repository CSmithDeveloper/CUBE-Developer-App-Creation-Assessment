// <copyright file="NinjectWebCommon.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CubeGlobal.TemperatureConverter.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CubeGlobal.TemperatureConverter.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace CubeGlobal.TemperatureConverter.WebAPI.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using CubeGlobal.TemperatureConverter.Repositories;
    using CubeGlobal.TemperatureConverter.RepositoryContracts;
    using CubeGlobal.TemperatureConverter.ServiceContracts;
    using CubeGlobal.TemperatureConverter.ServiceLibrary.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;
    using Self = NinjectWebCommon;

    /// <summary>
    /// Configures the Ninject web bindings.
    /// </summary>
    public static class NinjectWebCommon
    {
        /// <summary>
        /// The application bootstrapper.
        /// </summary>
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Self.Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Self.Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage the application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);

                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Registers the application's services.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAuditRepository>().To<AuditRepository>();
            kernel.Bind<IAuditService>().To<AuditService>();
            kernel.Bind<ITemperatureConverterService>().To<TemperatureConverterService>();
        }
    }
}