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

        // test initialize
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<HomeModel>>();

            pageModel = new HomeModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup
        
        // onGet method to return products
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
        }

        [Test]
        public void GetProduct_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var data = pageModel.Products;

            // Assert
            Assert.IsNull(data);
        }
        #endregion OnGet


    }
}