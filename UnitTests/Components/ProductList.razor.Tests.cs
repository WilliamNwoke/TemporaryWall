using Bunit;
using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region SelectProduct
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("The Starry Night"));
        }

        [Test]
        public void SelectProduct_Valid_ID_Exist_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "More Info";

            var page = RenderComponent<ProductList>();
            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find the one that matches the ID looking for and click it

            // Act




        }
        #endregion SelectProduct
    }
}