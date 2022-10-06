// <copyright file="ITemperatureConverterService.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceContracts
{
    using CubeGlobal.TemperatureConverter.Common;

    /// <summary>
    /// Defines the Temperature Converter Service contract.
    /// </summary>
    public interface ITemperatureConverterService
    {
        /// <summary>
        /// Converts the specified conversion value, to the specified temperature scale.
        /// </summary>
        /// <param name="convertFromScale">The convert from temperature scale.</param>
        /// <param name="convertToScale">The convert to temperature scale.</param>
        /// <param name="conversionValue">The conversion value.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>
        /// The converted temperature value.
        /// </returns>
        decimal ConvertTemperature(TemperatureScale convertFromScale, TemperatureScale convertToScale, decimal conversionValue, string userName);
    }
}