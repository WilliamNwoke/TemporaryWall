using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Read
{
    public class ReadTests
    {
        #region TestSetup
        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("the-starry-night");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("The Starry Night", pageModel.Product.Title);
        }
        #endregion OnGet

        
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

        #region SetComment
        [Test]
        public void SetComment_Valid_Should_Add()
        {
        // Arrange

        // Act

        // Assert
            
        }
        #endregion GetComment


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
            Assert.AreEqual(null, pageModel.Product.Comments); // nothing should be inserted
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Read"));
        }

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