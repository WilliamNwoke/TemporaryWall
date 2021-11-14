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

        /// <summary>
        /// Test Initialize method
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// onGet test to return a list of products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Data()
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