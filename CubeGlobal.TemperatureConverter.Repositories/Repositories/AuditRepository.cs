// <copyright file="AuditRepository.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.Repositories
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using CubeGlobal.TemperatureConverter.RepositoryContracts;
    using Self = AuditRepository;

    /// <summary>
    /// The Audit Repository.
    /// </summary>
    /// <remarks>
    /// A static variable has been used to simulate storing data to a database.
    /// The static variable will persist data across requests, until the IIS application pool is restarted/recycled.
    /// </remarks>
    /// <seealso cref="CubeGlobal.TemperatureConverter.RepositoryContracts.IAuditRepository" />
    public class AuditRepository : IAuditRepository
    {
        /// <summary>
        /// The conversion audit log.
        /// </summary>
        private static List<IAuditBO> conversionAuditLog;

        /// <summary>
        /// Initializes static members of the <see cref="AuditRepository"/> class.
        /// </summary>
        static AuditRepository()
        {
            Self.conversionAuditLog = new List<IAuditBO>();
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        internal static int Count => Self.conversionAuditLog.Count();

        /// <summary>
        /// Adds the conversion audit entry.
        /// </summary>
        /// <param name="auditEntry">The audit entry.</param>
        public void AddConversionAuditEntry(IAuditBO auditEntry)
        {
            Self.conversionAuditLog.Add(auditEntry);
        }

        /// <summary>
        /// Gets the complete conversion audit.
        /// </summary>
        /// <returns>
        /// The complete conversion audit, as a collection of Audit Business Objects (contracts).
        /// </returns>
        public Collection<IAuditBO> GetCompleteConversionAudit()
        {
            return new Collection<IAuditBO>(Self.conversionAuditLog);
        }
    }
}