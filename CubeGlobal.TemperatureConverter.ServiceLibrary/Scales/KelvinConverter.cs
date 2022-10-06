// <copyright file="KelvinConverter.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceLibrary.Scales
{
    using System;
    using CubeGlobal.TemperatureConverter.Common;
    using CubeGlobal.TemperatureConverter.ServiceLibrary.Interfaces;

    /// <summary>
    /// The Kelvin Converter.
    /// </summary>
    /// <seealso cref="CubeGlobal.TemperatureConverter.ServiceLibrary.Interfaces.IConverter" />
    internal class KelvinConverter : IConverter
    {
        /// <summary>
        /// Converts the specified convert to scale.
        /// Kelvin to Celsius Conversion        [°C] = [K] - 273.15
        /// Kelvin to Fahrenheit Conversion     [°F] = [K] × 9 / 5 - 459.67
        /// </summary>
        /// <param name="kelvinValue">The kelvin value.</param>
        /// <param name="convertToScale">The convert to temperature scale.</param>
        /// <returns>
        /// The converted temperature value.
        /// </returns>
        /// <exception cref="System.ArgumentException">The specified temperature scale '{0}', is not supported.</exception>
        public decimal Convert(decimal kelvinValue, TemperatureScale convertToScale)
        {
            switch (convertToScale)
            {
                case TemperatureScale.Celsius:
                    return kelvinValue - 273.15m;
                case TemperatureScale.Kelvin:
                    return kelvinValue;
                case TemperatureScale.Fahrenheit:
                    return (kelvinValue * 9 / 5) - 459.67m;
                default:
                    throw new ArgumentException($"The specified temperature scale '{convertToScale.ToString()}', is not supported.");
            }
        }
    }
}
