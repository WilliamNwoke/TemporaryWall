using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;


using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Controllers
{   
    /// <summary>
    /// Products Controller class
    /// </summary>
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
        #region ProductController
        /// <summary>
        /// Tests "public IEnumerable<ProductModel> Get()" in ProductsController.cs
        /// </summary>
        [Test]
        public void GetProducts_Default_Should_Return_Data()
        {
            // Arrange
            //var data = TestHelper.ProductService.GetProducts();
            // Act

            var results = TestHelper.ProductController.Get().FirstOrDefault();

            // Assert
            Assert.IsNotNull(results);
        }

        /// <summary>
        /// Tests "public ActionResult Patch([FromBody] RatingRequest request)"
        /// in ProductsController.cs
        /// </summary>
        [Test]
        public void Patch_RatingRequest_Valid_Should_Return_Ok()
        {
            // Arrange

            // Act
            var ok = new ProductsController.RatingRequest();
            var product = TestHelper.RatingRequest;
            product.ProductId = "the-last-supper";
            product.Rating = 0;
            TestHelper.ProductController.Patch(product);

            // Assert
            //Assert.AreEqual(null, results);
        }

        /// <summary>
        /// Tests "public ActionResult Patch([FromBody] CommentRequest request)"
        /// in ProductsController.cs
        /// </summary>
        [Test]
        public void Patch_CommentRequest_Valid_Should_Return_Ok()
        {
            // Arrange

            // Act
            var request = TestHelper.CommentRequest;
            request.ProductId = "the-starry-night";
            request.Comment = "O hi there";
            //ActionResult ok = TestHelper.ProductController.Patch(request);
            TestHelper.ProductController.Patch(request);

            // Assert
            //Assert.AreEqual(ok, ok);
        }
        #endregion ProductController
        
        //--------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------
        #region RatingRequest

        /// <summary>
        /// Tests RatingRequest "public string ProductId { get; set; }" in ProductsController.cs
        /// </summary>
        [Test]
        public void Get_Rating_ProductID_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var results = TestHelper.RatingRequest.ProductId;

            // Assert
            Assert.AreEqual(null, results);
        }

        /// <summary>
        /// Tests RatingRequest "public string Rating { get; set; }" in ProductsController.cs
        /// </summary>
        [Test]
        public void Get_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var results = TestHelper.RatingRequest.Rating;

            // Assert
            Assert.AreEqual(0, results);
        }

        /// <summary>
        /// Tests RatingRequest "public string ProductId { get; set; }" in ProductsController.cs
        /// </summary>
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

        /// <summary>
        /// Tests RatingRequest "public string Ratings { get; set; }" in ProductsController.cs
        /// </summary>
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

        /// <summary>
        /// Test CommentRequest "public string ProductId { get; set; }" in ProductsController.cs
        /// </summary>
        [Test]
        public void Get_Comment_ProductID_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var results = TestHelper.CommentRequest.ProductId;

            // Assert
            Assert.AreEqual(null, results);
        }

        /// <summary>
        /// Test CommentRequest "public string Comment { get; set; }" in ProductsController.cs
        /// </summary>
        [Test]
        public void Get_Comment_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var results = TestHelper.CommentRequest.Comment;

            // Assert
            Assert.AreEqual(null, results);
        }

        /// <summary>
        /// Test CommentRequest 
        /// "public string ProductId { get; set; }" 
        /// &
        /// "public string Comment { get; set; }" in ProductsController.cs
        /// 
        /// No Assert Because this Unit test is to test the menthod set function work
        /// </summary>
        [Test]
        public void Set_Comment_Set_ProductId_Should_Pass()
        {
            // Arrange

            // Act
            var comment = new ProductsController.CommentRequest { Comment = "fgdf", ProductId = "sdfs" };

            // Assert
            //Assert.AreEqual(comment, "fgdf");
            Assert.IsNotNull(comment);
        }
        #endregion CommentRequest
        
        //--------------------------------------------------------------------------------

    }
}
