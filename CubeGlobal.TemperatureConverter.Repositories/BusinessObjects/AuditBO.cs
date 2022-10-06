// <copyright file="AuditBO.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.Repositories.Models
{
    using System;
    using CubeGlobal.TemperatureConverter.Common;
    using CubeGlobal.TemperatureConverter.RepositoryContracts;

    /// <summary>
    /// The Audit Business Object.
    /// </summary>
    /// <seealso cref="CubeGlobal.TemperatureConverter.RepositoryContracts.IAuditBO" />
    public class AuditBO : IAuditBO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditBO"/> class.
        /// </summary>
        /// <param name="convertedFromScale">The converted from scale.</param>
        /// <param name="convertedFromValue">The converted from value.</param>
        /// <param name="convertedToScale">The converted to scale.</param>
        /// <param name="convertedToValue">The converted to value.</param>
        /// <param name="convertedBy">The converted by.</param>
        public AuditBO(TemperatureScale convertedFromScale, decimal convertedFromValue, TemperatureScale convertedToScale, decimal convertedToValue, string convertedBy)
        {
            this.Id = AuditRepository.Count + 1;
            this.ConvertedFromScale = convertedFromScale;
            this.ConvertedFromValue = convertedFromValue;
            this.ConvertedToScale = convertedToScale;
            this.ConvertedToValue = convertedToValue;
            this.ConvertedBy = convertedBy;
            this.ConvertedAt = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the converted from scale.
        /// </summary>
        /// <value>
        /// The converted from scale.
        /// </value>
        public TemperatureScale ConvertedFromScale { get; set; }

        /// <summary>
        /// Gets or sets the converted from value.
        /// </summary>
        /// <value>
        /// The converted from value.
        /// </value>
        public decimal ConvertedFromValue { get; set; }

        /// <summary>
        /// Gets or sets the converted to scale.
        /// </summary>
        /// <value>
        /// The converted to scale.
        /// </value>
        public TemperatureScale ConvertedToScale { get; set; }

        /// <summary>
        /// Gets or sets the converted to value.
        /// </summary>
        /// <value>
        /// The converted to value.
        /// </value>
        public decimal ConvertedToValue { get; set; }

        /// <summary>
        /// Gets or sets the converted by.
        /// </summary>
        /// <value>
        /// The converted by.
        /// </value>
        public string ConvertedBy { get; set; }

        /// <summary>
        /// Gets or sets the converted at.
        /// </summary>
        /// <value>
        /// The converted at.
        /// </value>
        public DateTime ConvertedAt { get; set; }
    }
}