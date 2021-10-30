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
        //--------------------------------------------------------------------------------
        #region TestSetup

        /// <summary>
        /// Initialize Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup
        //--------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------
        #region CommentRequest
        [Test]
        public void Get_Comment_ProductID_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var results = TestHelper.CommentRequest.ProductId;

            // Assert
            Assert.AreEqual(null, results);
        }

        [Test]
        public void Get_Comment_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var results = TestHelper.CommentRequest.Comment;

            // Assert
            Assert.AreEqual(null, results);
        }

        #endregion CommentRequest
        //--------------------------------------------------------------------------------
    }
}
