// <copyright file="IConverter.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceLibrary.Interfaces
{
    using CubeGlobal.TemperatureConverter.Common;

    /// <summary>
    /// Defines the Converter contract.
    /// </summary>
    internal interface IConverter
    {
        /// <summary>
        /// Converts the specified conversion value, to the specified temperature scale.
        /// </summary>
        /// <param name="conversionValue">The conversion value.</param>
        /// <param name="convertToScale">The convert to temperature scale.</param>
        /// <returns>
        /// The converted temperature value.
        /// </returns>
        decimal Convert(decimal conversionValue, TemperatureScale convertToScale);
    }
}
