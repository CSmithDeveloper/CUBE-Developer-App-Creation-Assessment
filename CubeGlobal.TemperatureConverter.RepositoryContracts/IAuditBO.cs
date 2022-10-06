// <copyright file="IAuditBO.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.RepositoryContracts
{
    using System;
    using CubeGlobal.TemperatureConverter.Common;

    /// <summary>
    /// Defines the Audit Business Object contract.
    /// </summary>
    public interface IAuditBO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the converted from scale.
        /// </summary>
        /// <value>
        /// The converted from scale.
        /// </value>
        TemperatureScale ConvertedFromScale { get; set; }

        /// <summary>
        /// Gets or sets the converted from value.
        /// </summary>
        /// <value>
        /// The converted from value.
        /// </value>
        decimal ConvertedFromValue { get; set; }

        /// <summary>
        /// Gets or sets the converted to scale.
        /// </summary>
        /// <value>
        /// The converted to scale.
        /// </value>
        TemperatureScale ConvertedToScale { get; set; }

        /// <summary>
        /// Gets or sets the converted to value.
        /// </summary>
        /// <value>
        /// The converted to value.
        /// </value>
        decimal ConvertedToValue { get; set; }

        /// <summary>
        /// Gets or sets the converted by.
        /// </summary>
        /// <value>
        /// The converted by.
        /// </value>
        string ConvertedBy { get; set; }

        /// <summary>
        /// Gets or sets the converted at.
        /// </summary>
        /// <value>
        /// The converted at.
        /// </value>
        DateTime ConvertedAt { get; set; }
    }
}