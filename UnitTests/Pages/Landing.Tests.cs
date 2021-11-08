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


        #region GetProductService
        [Test]
        public void Get_Should_Return_ProductService_Pass()
        {
            // Arrange


            // Act
            var data = pageModel.ProductService;

            // Assert

        }
        #endregion GetProductService


        #region GetProducts
        [Test]
        public void Products_Should_Get_Products_Valid_Pass()
        {
            // Arrange


            // Act
            var data = pageModel.Products;

            // Assert
        }
        #endregion GetProducts


        #region GetTopThreeArtworks
        [Test]
        public void TopThreeArtwork_Should_Get_TopThreeArtworks_Valid_Pass()
        {
            // Arrange


            // Act
            var data = pageModel.TopThreeArtwork;

            // Assert

        }
        #endregion GetTopThreeArtworks


        #region OnGet
        [Test]
        public void OnGet_Should_Return_TopThreeArtworks_Valid_Pass()
        {
            // Arrange


            // Act
            pageModel.OnGet();

            // Assert

        }
        #endregion OnGet
    }
}