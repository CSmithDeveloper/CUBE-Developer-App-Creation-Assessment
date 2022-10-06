// <copyright file="TemperatureConverterServiceTests.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.Repositories.IntegrationTests.Tests
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using CubeGlobal.TemperatureConverter.Common;
    using CubeGlobal.TemperatureConverter.Repositories;
    using CubeGlobal.TemperatureConverter.RepositoryContracts;
    using CubeGlobal.TemperatureConverter.ServiceLibrary.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Self = TemperatureConverterServiceTests;

    /// <summary>
    /// Integration tests for the Temperature Converter Service.
    /// </summary>
    /// <remarks>
    /// In this sample application, these are not actually integration tests but this project is here for demo purposes.
    /// In a production project, the Audit Repository would log to a database and running these tests would result in data being created in and then read from that database.
    /// A class clean-up method would then also execute, to remove the generated test data from the database.
    /// </remarks>    
    [TestClass]
    public class TemperatureConverterServiceTests
    {
        /// <summary>
        /// The default user.
        /// </summary>
        private const string DefaultUser = "AUser";

        /// <summary>
        /// The audit repository, System Under Test.
        /// </summary>
        private IAuditRepository auditRepositorySut;

        /// <summary>
        /// The temperature converter service
        /// </summary>
        private TemperatureConverterService temperatureConverterService;

        /// <summary>
        /// Initialises the test class before running each test.
        /// </summary>
        [TestInitialize]
        public void TestsInitialise()
        {
            this.auditRepositorySut = new AuditRepository();
            this.temperatureConverterService = new TemperatureConverterService(this.auditRepositorySut);

            _ = this.temperatureConverterService.ConvertTemperature(TemperatureScale.Celsius, TemperatureScale.Fahrenheit, 100, Self.DefaultUser);
            _ = this.temperatureConverterService.ConvertTemperature(TemperatureScale.Kelvin, TemperatureScale.Celsius, 200, Self.DefaultUser);
            _ = this.temperatureConverterService.ConvertTemperature(TemperatureScale.Fahrenheit, TemperatureScale.Kelvin, 300, Self.DefaultUser);
        }

        /// <summary>
        /// Verifies that three audit records are created and available within the repository, after running three temperature conversions.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration Tests")]
        public void GetCompleteConversionAudit_ConvertTemperatureCalledThreeTimes_ReturnsThreeAuditEntries()
        {
            Collection<IAuditBO> conversionAudit = this.auditRepositorySut.GetCompleteConversionAudit();

            Assert.AreEqual(3, conversionAudit.Count);
        }

        /// <summary>
        /// Verifies that the first audit record created, matches the first temperature conversion request.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration Tests")]
        public void GetCompleteConversionAudit_ConvertTemperatureCalledThreeTimes_ReturnsCorrectFirstAuditEntry()
        {
            Collection<IAuditBO> conversionAudit = this.auditRepositorySut.GetCompleteConversionAudit();

            IAuditBO auditEntry = conversionAudit.FirstOrDefault(a =>
                                                                 a.Id == 1 &&
                                                                 a.ConvertedFromScale == TemperatureScale.Celsius &&
                                                                 a.ConvertedFromValue == 100 &&
                                                                 a.ConvertedToScale == TemperatureScale.Fahrenheit &&
                                                                 a.ConvertedToValue == 212);

            Assert.IsNotNull(auditEntry);
        }

        /// <summary>
        /// Verifies that the second audit record created, matches the second temperature conversion request.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration Tests")]
        public void GetCompleteConversionAudit_ConvertTemperatureCalledThreeTimes_ReturnsCorrectSecondAuditEntry()
        {
            Collection<IAuditBO> conversionAudit = this.auditRepositorySut.GetCompleteConversionAudit();

            IAuditBO auditEntry = conversionAudit.FirstOrDefault(a =>
                                                                 a.Id == 2 &&
                                                                 a.ConvertedFromScale == TemperatureScale.Kelvin &&
                                                                 a.ConvertedFromValue == 200 &&
                                                                 a.ConvertedToScale == TemperatureScale.Celsius &&
                                                                 a.ConvertedToValue == -73.15m);

            Assert.IsNotNull(auditEntry);
        }

        /// <summary>
        /// Verifies that the third audit record created, matches the third temperature conversion request.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration Tests")]
        public void GetCompleteConversionAudit_ConvertTemperatureCalledThreeTimes_ReturnsCorrectThirdAuditEntry()
        {
            Collection<IAuditBO> conversionAudit = this.auditRepositorySut.GetCompleteConversionAudit();

            IAuditBO auditEntry = conversionAudit.FirstOrDefault(a =>
                                                                 a.Id == 3 &&
                                                                 a.ConvertedFromScale == TemperatureScale.Fahrenheit &&
                                                                 a.ConvertedFromValue == 300 &&
                                                                 a.ConvertedToScale == TemperatureScale.Kelvin &&
                                                                 a.ConvertedToValue == 422.03888888888888888888888889m);

            Assert.IsNotNull(auditEntry);
        }
    }
}