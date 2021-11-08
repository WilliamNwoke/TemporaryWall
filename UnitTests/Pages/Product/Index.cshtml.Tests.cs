using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{   
    /// <summary>
    /// Unit test for the index functionality
    /// </summary>
    public class IndexTests
    {   
        // Test to see the management of index file
        #region TestSetup
        public static PageContext pageContext;
        public static IndexModel pageModel;

        [SetUp]

        // Test Initialize method
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        // onGet test to return a list of products
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Pass()
        {
            // Arrange
            pageModel.OnGet();

            // Act
            var data = pageModel.Products.FirstOrDefault();

            // Assert
            Assert.IsNotNull(data);
        }
        #endregion OnGet
    }
}