// <copyright file = "HomeViewModel.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.UI.Models
{
    using System.Collections.Generic;
    using CubeGlobal.TemperatureConverter.Common;

    /// <summary>
    /// The view model for the home page.
    /// </summary>
    public class HomeViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        /// <param name="convert">The convert.</param>
        /// <param name="audit">The audit.</param>
        public HomeViewModel(ConvertModel convert, List<AuditModel> audit)
        {
            this.Convert = convert;
            this.Audit = audit;
        }

        /// <summary>
        /// Gets or sets the convert model.
        /// </summary>
        /// <value>
        /// The convert model.
        /// </value>
        public ConvertModel Convert { get; set; }

        /// <summary>
        /// Gets or sets the audit model.
        /// </summary>
        /// <value>
        /// The audit model.
        /// </value>
        public List<AuditModel> Audit { get; set; }

        /// <summary>
        /// Formats the temperature value.
        /// </summary>
        /// <param name="scale">The scale.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The formatted temperature value.
        /// </returns>
        public static string FormatTemperatureValue(TemperatureScale scale, decimal value)
        {
            const string DegreeSymbol = "°";
            string unit;
            switch (scale)
            {
                case TemperatureScale.Celsius:
                    unit = string.Concat("C", DegreeSymbol);
                    break;
                case TemperatureScale.Kelvin:
                    unit = "K";
                    break;
                case TemperatureScale.Fahrenheit:
                    unit = string.Concat("F", DegreeSymbol);
                    break;
                default:
                    unit = string.Empty;
                    break;
            }

            return string.Concat(string.Format("{0:0.##}", value.ToString()), " ", unit);
        }
    }
}