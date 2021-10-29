using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Controllers
{
    public class ProductsControllers
    {
        #region TestSetup

        /// <summary>
        /// Initialize Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup


        #region ProductService
        public static void Get_ProductService_Valid_Should_Return_JsonFileProductService()
        {
            // Arrange

            // Act
            var products = TestHelper.ProductService.GetProducts();
            var results = TestHelper.ProductController.Get();

            // Assert
            Assert.AreEqual(products, results);
        }

        #endregion ProductService
    }
}
