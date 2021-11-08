using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Landing
{
    /// <summary>
    /// Json Product services test
    /// </summary>
    public class LandingTests
    {
        #region TestSetup
        public static LandingModel pageModel;

        // test initialize
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new LandingModel(TestHelper.ProductService);
        }
        #endregion TestSetup


        #region Get
        [Test]
        public void Get_Should_Return_ProductService_Pass()
        {
            // Arrange


            // Act
            var data = pageModel.ProductService;

            // Assert

        }
        #endregion Get
    }
}