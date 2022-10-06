// <copyright file="AuditService.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceLibrary.Services
{
    using System.Collections.ObjectModel;
    using CubeGlobal.TemperatureConverter.RepositoryContracts;
    using CubeGlobal.TemperatureConverter.ServiceContracts;
    using CubeGlobal.TemperatureConverter.ServiceLibrary.Mappers;

    /// <summary>
    /// The Audit Service.
    /// </summary>
    /// <seealso cref="CubeGlobal.TemperatureConverter.ServiceContracts.IAuditService" />
    public class AuditService : IAuditService
    {
        /// <summary>
        /// The audit repository.
        /// </summary>
        private readonly IAuditRepository auditRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditService"/> class.
        /// </summary>
        /// <param name="auditRepository">The audit repository.</param>
        public AuditService(IAuditRepository auditRepository)
        {
            this.auditRepository = auditRepository;
        }

        /// <summary>
        /// Gets the audit entries.
        /// </summary>
        /// <returns>
        /// The complete conversion audit, as a collection of Audit Business Objects (contracts).
        /// </returns>
        public Collection<IAuditDTO> GetAuditEntries()
        {
            Collection<IAuditBO> auditEntries = this.auditRepository.GetCompleteConversionAudit();
            Collection<IAuditDTO> response = auditEntries.MapToDTO();

            return response;
        }
    }
}