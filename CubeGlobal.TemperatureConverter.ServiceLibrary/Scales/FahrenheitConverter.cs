// <copyright file="FahrenheitConverter.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceLibrary.Scales
{
    using System;
    using CubeGlobal.TemperatureConverter.Common;
    using CubeGlobal.TemperatureConverter.ServiceLibrary.Interfaces;

    /// <summary>
    /// The Fahrenheit Converter.
    /// </summary>
    /// <seealso cref="CubeGlobal.TemperatureConverter.ServiceLibrary.Interfaces.IConverter" />
    internal class FahrenheitConverter : IConverter
    {
        /// <summary>
        /// Converts the specified convert to scale.
        /// Fahrenheit to Celsius Conversion    [°C] = ([°F] - 32) × 5/9
        /// Fahrenheit to Kelvin Conversion     [K] = ([°F] + 459.67) × 5/9
        /// </summary>
        /// <param name="fahrenheitValue">The fahrenheit value.</param>
        /// <param name="convertToScale">The convert to temperature scale.</param>
        /// <returns>
        /// The converted temperature value.
        /// </returns>
        /// <exception cref="System.ArgumentException">The specified temperature scale '{0}', is not supported.</exception>        
        public decimal Convert(decimal fahrenheitValue, TemperatureScale convertToScale)
        {
            switch (convertToScale)
            {
                case TemperatureScale.Celsius:
                    return (fahrenheitValue - 32) * 5 / 9;
                case TemperatureScale.Kelvin:
                    return (fahrenheitValue + 459.67m) * 5 / 9;
                case TemperatureScale.Fahrenheit:
                    return fahrenheitValue;
                default:
                    throw new ArgumentException($"The specified temperature scale '{convertToScale.ToString()}', is not supported.");
            }
        }
    }
}
