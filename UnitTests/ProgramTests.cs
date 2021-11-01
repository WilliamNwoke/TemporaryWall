using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

using NUnit.Framework;
using ContosoCrafts.WebSite;

using Moq;

namespace UnitTests.Program
{
    /// <summary>
    /// program test class
    /// </summary>
    public class ProgramTests
    {
        // test initialize
        #region TestSetup
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup
        
        //  Program. cs test function

        #region CreateHostBuilder
        [Test,Timeout(1000)]
        public void Program_CreateHostBuilder_Valid_Defaut_Should_Pass()
        {            
            // Arrange
            string[] args = null;

            // Act
            ContosoCrafts.WebSite.Program.CreateHostBuilder(args);

            // Assert

        }
        #endregion CreateHostBuilder


    }
}