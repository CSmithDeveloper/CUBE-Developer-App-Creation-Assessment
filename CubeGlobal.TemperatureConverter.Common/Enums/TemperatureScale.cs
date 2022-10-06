// <copyright file="TemperatureScale.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.Common
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines the temperature scales.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TemperatureScale
    {
        /// <summary>
        /// The celsius temperature scale.
        /// </summary>
        Celsius,

        /// <summary>
        /// The kelvin temperature scale.
        /// </summary>
        Kelvin,

        /// <summary>
        /// The fahrenheit temperature scale.
        /// </summary>
        Fahrenheit
    }
}