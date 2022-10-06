// <copyright file="AuditController.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.WebAPI.Controllers
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using CubeGlobal.TemperatureConverter.RepositoryContracts;
    using CubeGlobal.TemperatureConverter.ServiceContracts;

    /// <summary>
    /// The Audit Controller.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class AuditController : ApiController
    {
        /// <summary>
        /// The audit service.
        /// </summary>
        private readonly IAuditService auditService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditController"/> class.
        /// </summary>
        /// <param name="auditService">The audit service.</param>
        public AuditController(IAuditService auditService)
        {
            this.auditService = auditService;
        }

        /// <summary>
        /// Gets the audit entries.
        /// </summary>
        /// <returns>
        /// The audit entries.
        /// </returns>
        [HttpGet]
        [Route("api/Audit")]
        public IHttpActionResult GetAuditEntries()
        {
            Collection<IAuditDTO> auditEntries = this.auditService.GetAuditEntries();
            auditEntries.ToList().ForEach(a =>
            {
                a.ConvertedFromValue = Math.Round(a.ConvertedFromValue, 4);
                a.ConvertedToValue = Math.Round(a.ConvertedToValue, 4);
            });

            return this.ResponseMessage(this.Request.CreateResponse(HttpStatusCode.OK, auditEntries));
        }
    }
}