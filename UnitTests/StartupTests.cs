using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

using NUnit.Framework;
using System;

namespace UnitTests.Startup
{
    /// <summary>
    /// Startup test file
    /// </summary>
    public class StartupTests
    {
        #region TestSetup
        /// <summary>
        /// Initialize setup
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        /// <summary>
        /// Test for entry point of the application
        /// </summary>
        public class Startup : ContosoCrafts.WebSite.Startup
        {
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        /// <summary>
        /// test function for application configure services
        /// </summary>
        #region ConfigureServices
        [Test]
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices

        /// <summary>
        /// test function for application entry point configuration
        /// </summary>
        #region GetConfiguration
        [Test]
        public void Startup_Get_Configuration_Should_Pass()
        {
            Startup startup = new Startup(new ConfigurationBuilder().Build());
            Assert.IsNotNull(startup.Configuration);
        }

        #endregion GetConfiguration
    }
}