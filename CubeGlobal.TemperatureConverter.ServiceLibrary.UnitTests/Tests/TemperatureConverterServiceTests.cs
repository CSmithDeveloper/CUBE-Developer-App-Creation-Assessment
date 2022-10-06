// <copyright file="TemperatureConverterServiceTests.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceLibrary.UnitTests.Tests
{
    using CubeGlobal.TemperatureConverter.Common;
    using CubeGlobal.TemperatureConverter.Repositories.Models;
    using CubeGlobal.TemperatureConverter.RepositoryContracts;
    using CubeGlobal.TemperatureConverter.ServiceLibrary.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Self = TemperatureConverterServiceTests;

    /// <summary>
    /// Unit tests for the Temperature Converter Service.
    /// </summary>
    [TestClass]
    public class TemperatureConverterServiceTests
    {
        /// <summary>
        /// The default user
        /// </summary>
        private const string DefaultUser = "AUser";

        /// <summary>
        /// The mock audit repository implementation.
        /// </summary>
        private Mock<IAuditRepository> auditRepositoryImplementation;

        /// <summary>
        /// The mock audit repository.
        /// </summary>
        private IAuditRepository auditRepository;

        /// <summary>
        /// The temperature converter service, System Under Test.
        /// </summary>
        private TemperatureConverterService temperatureConverterServiceSut;

        /// <summary>
        /// Initialises the test class before running each test.
        /// </summary>
        [TestInitialize]
        public void TestsInitialise()
        {
            this.auditRepositoryImplementation = new Mock<IAuditRepository>();
            this.auditRepository = this.auditRepositoryImplementation.Object;

            this.temperatureConverterServiceSut = new TemperatureConverterService(this.auditRepository);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive integer from Celsius to Kelvin.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Celsius Tests")]
        public void ConvertTemperature_CelsiusToKelvinPositiveInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Kelvin, 70, Self.DefaultUser);
            Assert.AreEqual(343.15m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative integer from Celsius to Kelvin.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Celsius Tests")]
        public void ConvertTemperature_CelsiusToKelvinNegativeInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Kelvin, -90, Self.DefaultUser);
            Assert.AreEqual(183.15m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive decimal from Celsius to Kelvin.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Celsius Tests")]
        public void ConvertTemperature_CelsiusToKelvinPositiveDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Kelvin, 26.486m, Self.DefaultUser);
            Assert.AreEqual(299.636m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative decimal from Celsius to Kelvin.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Celsius Tests")]
        public void ConvertTemperature_CelsiusToKelvinNegativeDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Kelvin, -7489.45m, Self.DefaultUser);
            Assert.AreEqual(-7216.3m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive integer from Celsius to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Celsius Tests")]
        public void ConvertTemperature_CelsiusToFahrenheitPositiveInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Fahrenheit, 25, Self.DefaultUser);
            Assert.AreEqual(77, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative integer from Celsius to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Celsius Tests")]
        public void ConvertTemperature_CelsiusToFahrenheitNegativeInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Fahrenheit, -20, Self.DefaultUser);
            Assert.AreEqual(-4, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive decimal from Celsius to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Celsius Tests")]
        public void ConvertTemperature_CelsiusToFahrenheitPositiveDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Fahrenheit, 25.78m, Self.DefaultUser);
            Assert.AreEqual(78.404m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative decimal from Celsius to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Celsius Tests")]
        public void ConvertTemperature_CelsiusToFahrenheitNegativeDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Fahrenheit, -489.45m, Self.DefaultUser);
            Assert.AreEqual(-849.01m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the original input value when converting from Celsius to Celsius.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Celsius Tests")]
        public void ConvertTemperature_CelsiusToCelsius_ReturnsInputValue()
        {
            const decimal InputValue = 45;
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Celsius, InputValue, Self.DefaultUser);
            Assert.AreEqual(InputValue, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive integer from Kelvin to Celsius.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Kelvin Tests")]
        public void ConvertTemperature_KelvinToCelsiusPositiveInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Kelvin, TemperatureScale.Celsius, 23, Self.DefaultUser);
            Assert.AreEqual(-250.15m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative integer from Kelvin to Celsius.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Kelvin Tests")]
        public void ConvertTemperature_KelvinToCelsiusNegativeInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Kelvin, TemperatureScale.Celsius, -84, Self.DefaultUser);
            Assert.AreEqual(-357.15m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive decimal from Kelvin to Celsius.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Kelvin Tests")]
        public void ConvertTemperature_KelvinToCelsiusPositiveDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Kelvin, TemperatureScale.Celsius, 489.154m, Self.DefaultUser);
            Assert.AreEqual(216.004m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative decimal from Kelvin to Celsius.
        /// </summary> 
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Kelvin Tests")]
        public void ConvertTemperature_KelvinToCelsiusNegativeDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Kelvin, TemperatureScale.Celsius, -145.589m, Self.DefaultUser);
            Assert.AreEqual(-418.739m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive integer from Kelvin to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Kelvin Tests")]
        public void ConvertTemperature_KelvinToFahrenheitPositiveInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Kelvin, TemperatureScale.Fahrenheit, 47, Self.DefaultUser);
            Assert.AreEqual(-375.07m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative integer from Kelvin to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Kelvin Tests")]
        public void ConvertTemperature_KelvinToFahrenheitNegativeInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Kelvin, TemperatureScale.Fahrenheit, -130, Self.DefaultUser);
            Assert.AreEqual(-693.67m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive decimal from Kelvin to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Kelvin Tests")]
        public void ConvertTemperature_KelvinToFahrenheitPositiveDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Kelvin, TemperatureScale.Fahrenheit, 14789.256m, Self.DefaultUser);
            Assert.AreEqual(26160.9908m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative decimal from Kelvin to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Kelvin Tests")]
        public void ConvertTemperature_KelvinToFahrenheitNegativeDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Kelvin, TemperatureScale.Fahrenheit, -78, Self.DefaultUser);
            Assert.AreEqual(-600.07m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the original input value when converting from Kelvin to Kelvin.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Kelvin Tests")]
        public void ConvertTemperature_KelvinToKelvin_ReturnsInputValue()
        {
            const decimal InputValue = 84;
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Kelvin, TemperatureScale.Kelvin, InputValue, Self.DefaultUser);
            Assert.AreEqual(InputValue, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive integer from Fahrenheit to Celsius.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Fahrenheit Tests")]
        public void ConvertTemperature_FahrenheitToCelsiusPositiveInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Fahrenheit, TemperatureScale.Celsius, 489, Self.DefaultUser);
            Assert.AreEqual(253.88888888888888888888888889m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative integer from Fahrenheit to Celsius.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Fahrenheit Tests")]
        public void ConvertTemperature_FahrenheitToCelsiusNegativeInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Fahrenheit, TemperatureScale.Celsius, -73, Self.DefaultUser);
            Assert.AreEqual(-58.333333333333333333333333333m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive decimal from Fahrenheit to Celsius.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Fahrenheit Tests")]
        public void ConvertTemperature_FahrenheitToCelsiusPositiveDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Fahrenheit, TemperatureScale.Celsius, 77.589m, Self.DefaultUser);
            Assert.AreEqual(25.327222222222222222222222222m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative decimal from Fahrenheit to Celsius.
        /// </summary> 
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Fahrenheit Tests")]
        public void ConvertTemperature_FahrenheitToCelsiusNegativeDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Fahrenheit, TemperatureScale.Celsius, -36.57m, Self.DefaultUser);
            Assert.AreEqual(-38.094444444444444444444444444m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive integer from Fahrenheit to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Fahrenheit Tests")]
        public void ConvertTemperature_FahrenheitToKelvinPositiveInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Fahrenheit, TemperatureScale.Kelvin, 849, Self.DefaultUser);
            Assert.AreEqual(727.03888888888888888888888889m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative integer from Fahrenheit to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Fahrenheit Tests")]
        public void ConvertTemperature_FahrenheitToKelvinNegativeInteger_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Fahrenheit, TemperatureScale.Kelvin, -2859, Self.DefaultUser);
            Assert.AreEqual(-1332.9611111111111111111111111m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a positive decimal from Fahrenheit to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Fahrenheit Tests")]
        public void ConvertTemperature_FahrenheitToKelvinPositiveDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Fahrenheit, TemperatureScale.Kelvin, 14789.256m, Self.DefaultUser);
            Assert.AreEqual(8471.625555555555555555555556m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the expected value when converting a negative decimal from Fahrenheit to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Fahrenheit Tests")]
        public void ConvertTemperature_FahrenheitToKelvinNegativeDecimal_ReturnsExpectedValue()
        {
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Fahrenheit, TemperatureScale.Kelvin, -854.44m, Self.DefaultUser);
            Assert.AreEqual(-219.31666666666666666666666667m, convertedValue);
        }

        /// <summary>
        /// Verifies that the ConvertTemperature method, returns the original input value when converting from Fahrenheit to Fahrenheit.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        [TestCategory("Fahrenheit Tests")]
        public void ConvertTemperature_FahrenheitToFahrenheit_ReturnsInputValue()
        {
            const decimal InputValue = 99;
            decimal convertedValue = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Fahrenheit, TemperatureScale.Fahrenheit, InputValue, Self.DefaultUser);
            Assert.AreEqual(InputValue, convertedValue);
        }
                                 
        /// <summary>
        /// Verifies that the ConvertTemperature method, calls the AddConversionAuditEntry Audit Repository method once.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        public void ConvertTemperature_AnyArguments_LogToAuditIsCalledOnce()
        {
            _ = this.temperatureConverterServiceSut.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Fahrenheit, 100, Self.DefaultUser);
            this.auditRepositoryImplementation.Verify(m => m.AddConversionAuditEntry(It.IsAny<AuditBO>()), Times.Once);
        }
    }
}