using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

using NUnit.Framework;
using System;

namespace UnitTests.Startup
{
    public class StartupTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        public class Startup : ContosoCrafts.WebSite.Startup
        {
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        #region ConfigureServices
        [Test]
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices

        #region GetConfiguration
        [Test]
        public void Startup_Get_Configuration_Should_Pass()
        {
            Startup startup = new Startup(new ConfigurationBuilder().Build());
            Assert.IsNotNull(startup.Configuration);
        }

        #endregion GetConfiguration

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