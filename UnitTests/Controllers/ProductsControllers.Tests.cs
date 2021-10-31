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
        #region RatingRequest
        [Test]
        public void Get_Rating_ProductID_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var results = TestHelper.RatingRequest.ProductId;

            // Assert
            Assert.AreEqual(null, results);
        }

        [Test]
        public void Get_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var results = TestHelper.RatingRequest.Rating;

            // Assert
            Assert.AreEqual(0, results);
        }

        [Test]
        public void Set_Rating_ProductID_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var results = TestHelper.RatingRequest;
            results.ProductId = null;

            // Assert
            Assert.AreEqual(null, results.ProductId);
        }

        [Test]
        public void Set_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var results = TestHelper.RatingRequest;
            results.Rating = 5;

            // Assert
            Assert.AreEqual(5, results.Rating);
        }
        #endregion RatingRequest
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


        //No Assert Because this Unit test is to test the menthod set function work
        #region SetCommentSetProductId
        [Test]
        public void Set_Comment_Set_ProductId_Should_Pass()
        {
            // Arrange

            // Act
            var comment = new ProductsController.CommentRequest { Comment = "fgdf", ProductId = "sdfs" };

            // Assert

        }
        #endregion SetComment
        //--------------------------------------------------------------------------------

    }
}
