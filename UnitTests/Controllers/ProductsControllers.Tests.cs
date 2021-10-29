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
        //Variable for product controller
        public static JsonFileProductService productService;

        /// <summary>
        /// Initialize Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            controller = new ProductsControllers(productService)
            {
            };
        }

        #endregion TestSetup


        #region Get
        public void Get_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            var products = controller.Get();

            // Assert

        }

        #endregion Get
    }
}
