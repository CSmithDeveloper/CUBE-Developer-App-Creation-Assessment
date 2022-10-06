// <copyright file="CelsiusConverter.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceLibrary.Scales
{
    using System;
    using CubeGlobal.TemperatureConverter.Common;
    using CubeGlobal.TemperatureConverter.ServiceLibrary.Interfaces;

    /// <summary>
    /// The Celsius Converter.
    /// </summary>
    /// <seealso cref="CubeGlobal.TemperatureConverter.ServiceLibrary.Interfaces.IConverter" />
    internal class CelsiusConverter : IConverter
    {
        /// <summary>
        /// Converts the specified conversion value, to the specified temperature scale, using the following formulas:
        /// Celsius to Kelvin Conversion        [K] = [°C] + 273.15
        /// Celsius to Fahrenheit Conversion    [°F] = [°C] × 9/5 + 32
        /// </summary>
        /// <param name="celsiusValue">The celsius value.</param>
        /// <param name="convertToScale">The convert to temperature scale.</param>
        /// <returns>
        /// The converted temperature value.
        /// </returns>
        /// <exception cref="System.ArgumentException">The specified temperature scale '{0}', is not supported.</exception>
        public decimal Convert(decimal celsiusValue, TemperatureScale convertToScale)
        {
            switch (convertToScale)
            {
                case TemperatureScale.Celsius:
                    return celsiusValue;
                case TemperatureScale.Kelvin:
                    return celsiusValue + 273.15m;
                case TemperatureScale.Fahrenheit:
                    return (celsiusValue * 9 / 5) + 32;
                default:
                    throw new ArgumentException($"The specified temperature scale '{convertToScale.ToString()}', is not supported.");
            }
        }
    }
}