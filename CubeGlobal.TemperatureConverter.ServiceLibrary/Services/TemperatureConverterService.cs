// <copyright file="TemperatureConverterService.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceLibrary.Services
{
    using System;
    using CubeGlobal.TemperatureConverter.Common;
    using CubeGlobal.TemperatureConverter.Repositories.Models;
    using CubeGlobal.TemperatureConverter.RepositoryContracts;
    using CubeGlobal.TemperatureConverter.ServiceContracts;
    using CubeGlobal.TemperatureConverter.ServiceLibrary.Interfaces;
    using CubeGlobal.TemperatureConverter.ServiceLibrary.Scales;

    /// <summary>
    /// The Temperature Converter Service.
    /// </summary>
    /// <seealso cref="CubeGlobal.TemperatureConverter.ServiceContracts.ITemperatureConverterService" />
    public class TemperatureConverterService : ITemperatureConverterService
    {
        /// <summary>
        /// The audit repository.
        /// </summary>
        private readonly IAuditRepository auditRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemperatureConverterService"/> class.
        /// </summary>
        /// <param name="auditRepository">The audit repository.</param>
        public TemperatureConverterService(IAuditRepository auditRepository)
        {
            this.auditRepository = auditRepository;
        }

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
        public decimal ConvertTemperature(TemperatureScale convertFromScale, TemperatureScale convertToScale, decimal conversionValue, string userName)
        {
            IConverter converter = this.ConverterFactory(convertFromScale);
            decimal convertedValue = converter.Convert(conversionValue, convertToScale);

            this.LogToAudit(convertFromScale, convertToScale, conversionValue, userName, convertedValue);

            return convertedValue;
        }

        /// <summary>
        /// Logs to audit.
        /// </summary>
        /// <param name="convertFromScale">The convert from temperature scale.</param>
        /// <param name="convertToScale">The convert to temperature scale.</param>
        /// <param name="conversionValue">The conversion value.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="convertedValue">The converted value.</param>
        private void LogToAudit(TemperatureScale convertFromScale, TemperatureScale convertToScale, decimal conversionValue, string userName, decimal convertedValue)
        {
            var auditEntry = new AuditBO(convertFromScale, conversionValue, convertToScale, convertedValue, userName);
            this.auditRepository.AddConversionAuditEntry(auditEntry);
        }

        /// <summary>
        /// Creates a temperature converter object, appropriate to the supplied convert from temperature scale.
        /// </summary>
        /// <param name="convertFromScale">The convert from temperature scale.</param>
        /// <returns>
        /// A temperature converter object
        /// </returns>
        /// <exception cref="System.ArgumentException">The specified temperature scale '{0}', is not supported.</exception>
        private IConverter ConverterFactory(TemperatureScale convertFromScale)
        {
            switch (convertFromScale)
            {
                case TemperatureScale.Celsius:
                    return new CelsiusConverter();
                case TemperatureScale.Kelvin:
                    return new KelvinConverter();
                case TemperatureScale.Fahrenheit:
                    return new FahrenheitConverter();
                default:
                    throw new ArgumentException($"The specified temperature scale '{convertFromScale.ToString()}', is not supported.");
            }
        }
    }
}