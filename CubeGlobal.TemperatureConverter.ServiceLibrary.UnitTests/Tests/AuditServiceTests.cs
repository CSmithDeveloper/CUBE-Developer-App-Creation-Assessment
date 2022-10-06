// <copyright file="AuditServiceTests.cs" company="Cube Global">
//     Copyright © 2022 Cube Global. All rights reserved.
// </copyright>
// <author>Christopher Smith - Senior Developer</author>

namespace CubeGlobal.TemperatureConverter.ServiceLibrary.UnitTests.Tests
{
    using CubeGlobal.TemperatureConverter.RepositoryContracts;
    using CubeGlobal.TemperatureConverter.ServiceLibrary.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Unit tests for the Audit Service.
    /// </summary>
    [TestClass]
    public class AuditServiceTests
    {
        /// <summary>
        /// The mock audit repository implementation.
        /// </summary>
        private Mock<IAuditRepository> auditRepositoryImplementation;

        /// <summary>
        /// The mock audit repository.
        /// </summary>
        private IAuditRepository auditRepository;

        /// <summary>
        /// The audit service, System Under Test.
        /// </summary>
        private AuditService auditServiceSut;

        /// <summary>
        /// Initialises the test class before running each test.
        /// </summary>
        [TestInitialize]
        public void TestsInitialise()
        {
            this.auditRepositoryImplementation = new Mock<IAuditRepository>();
            this.auditRepository = this.auditRepositoryImplementation.Object;

            this.auditServiceSut = new AuditService(this.auditRepository);
        }

        /// <summary>
        /// Verifies that the GetAuditEntries method, calls the GetCompleteConversionAudit Audit Repository method once.
        /// </summary>
        [TestMethod]
        [TestCategory("Unit Tests")]
        public void GetAuditEntries_AnyArguments_LogToAuditIsCalledOnce()
        {
            _ = this.auditServiceSut.GetAuditEntries();            
            this.auditRepositoryImplementation.Verify(m => m.GetCompleteConversionAudit(), Times.Once);
        }
    }
}