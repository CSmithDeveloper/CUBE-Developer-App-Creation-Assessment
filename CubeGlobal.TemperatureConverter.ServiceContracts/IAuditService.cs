// <copyright file="IAuditService.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceContracts
{
    using System.Collections.ObjectModel;
    using CubeGlobal.TemperatureConverter.RepositoryContracts;

    /// <summary>
    /// Defines the Audit Service contract.
    /// </summary>
    public interface IAuditService
    {
        /// <summary>
        /// Gets the audit entries.
        /// </summary>
        /// <returns>
        /// The complete conversion audit, as a collection of Audit Business Objects (contracts).
        /// </returns>
        Collection<IAuditDTO> GetAuditEntries();
    }
}