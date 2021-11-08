using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Product.Read
{   
    /// <summary>
    /// Test for the read functionality of the products page
    /// </summary>
    public class ReadTests
    {
        // Read Model Page Model function
        #region TestSetup
        public static ReadModel pageModel;

        // Test Initializer function
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService);
        }
        #endregion TestSetup

        // onGet test method to read and return the product argument passed.
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("the-starry-night");
            pageModel.Product.ToString();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("The Starry Night", pageModel.Product.Title);
        }
        #endregion OnGet

        // get method which returns the comments
        #region GetComment
        [Test]
        public void GetComment_Valid_Should_Pass()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(null, pageModel.Comment);
        }
        #endregion GetComment


        // Test OnPost method to pass, when comments is NULL
        #region OnPost
        [Test]
        public void OnPost_Comment_Null_Should_Pass()
        {
            // Arrange
            pageModel.Comment = null;
            pageModel.Product = new ProductModel
            {
                Id = "selinazawacki-moon",
                Title = "title",
                Description = "description",
                Image = "image"
            };
            // Act
            var result = pageModel.OnPost() as RedirectToPageResult; 

            // Assert 
            // nothing should be inserted
            Assert.AreEqual(null, pageModel.Product.Comments);
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Read"));
        }
        
        // onPost Method to Pass when comment is blank
        [Test]
        public void OnPost_Comment_Blank_Should_Pass()
        {
            // Arrange
            pageModel.Comment = ""; // empty comment
            pageModel.Product = new ProductModel
            {
                Id = "selinazawacki-moon",
                Title = "title",
                Description = "description",
                Image = "image"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(null, pageModel.Product.Comments); // nothing should be inserted
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Read"));
        }

        // OnPost  
        [Test]
        public void OnPost_Comment_Too_Long_Should_Pass()
        {
            // Arrange
            // 251 character length comment
            pageModel.Comment = "324o1324po1234u1p324u1o32i4u1po23i4" +
                "u1po23iu4p1o32iu4p1o2i3u4p1o23iu4p1oi32u4p1oi23u4p1" +
                "oi23u4p1oi3u4p1oi3u41poi3u41poi32u41poi32u41po23iu4" +
                "1poiadsfadsfadsfasdfasdfadsfadslfkja;dlskfja;ldskfj" +
                "a;ldksfj;alsdkfja;dlskfja;ldskfjdfdfdfdfdfdfdfdfdfd" +
                "fdfdfdfdfdfd";
            pageModel.Product = new ProductModel
            {
                Id = "selinazawacki-moon",
                Title = "title",
                Description = "description",
                Image = "image"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(null, pageModel.Product.Comments); // nothing should be inserted
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Read"));
        }

        [Test]
        public void OnPost_Comment_Valid_Should_Pass()
        {
            // Arrange
            // 251 character length comment
            pageModel.Comment = "What a great comment this is";            
            pageModel.Product = TestHelper.ProductService.GetProducts().Last();

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;
            // Retreive the updated comment
            var data = TestHelper.ProductService.GetProducts().First(x => x.Id == pageModel.Product.Id);

            // Assert
            Assert.AreEqual(1, data.Comments.Length); // 1 comment should be added
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Read"));
        }
        #endregion OnPost*/

        #region ReadModelSetComment
        [Test]
        public void ReadModel_Set_Comment_Should_Pass()
        {
            // Arrange
            var comment = new ReadModel(TestHelper.ProductService){ Comment = ""};

            // Act

            // Assert
        }
        #endregion ReadModelSetComment
    }
}