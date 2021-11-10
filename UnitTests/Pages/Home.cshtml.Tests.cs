using System.Linq;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Home
{
    /// <summary>
    /// Index test unit test
    /// </summary>
    public class IndexTests
    {
        #region TestSetup
        // Page model declaration
        public static HomeModel pageModel;

        /// <summary>
        /// Initialize mocks and models
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<HomeModel>>();

            pageModel = new HomeModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// onGet method to return products
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
        }
        #endregion OnGet
    }
}