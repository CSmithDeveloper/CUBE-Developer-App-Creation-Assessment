// <copyright file="IAuditRepository.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.RepositoryContracts
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the Audit Repository contract.
    /// </summary>
    public interface IAuditRepository
    {
        /// <summary>
        /// Adds the conversion audit entry.
        /// </summary>
        /// <param name="auditEntry">The audit entry.</param>
        void AddConversionAuditEntry(IAuditBO auditEntry);

        /// <summary>
        /// Gets the complete conversion audit.
        /// </summary>
        /// <returns>
        /// The complete conversion audit, as a collection of Audit Business Objects (contracts).
        /// </returns>
        Collection<IAuditBO> GetCompleteConversionAudit();
    }
}