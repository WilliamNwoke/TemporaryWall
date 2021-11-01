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
        // Test initialize
        [SetUp]
        public void TestInitialize()
        {
        }
        // Test for entry point of the application
        public class Startup : ContosoCrafts.WebSite.Startup
        {
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        // test function for application configure services
        #region ConfigureServices
        [Test]
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices

        // test function for application entry point configuration
        #region GetConfiguration
        [Test]
        public void Startup_Get_Configuration_Should_Pass()
        {
            Startup startup = new Startup(new ConfigurationBuilder().Build());
            Assert.IsNotNull(startup.Configuration);
        }

        #endregion GetConfiguration

        // test function for application entry point
        #region Configure
        [Test]
        public void Startup_Configure_Should_Pass()
        {
            Startup startup = new Startup(new ConfigurationBuilder().Build());
            //startup.Configure(new ApplicationBuilder(IServiceProvider.GetService(typeof(IService))), TestHelper.WebHostEnvironment);
        }
        #endregion Configure
    }
}