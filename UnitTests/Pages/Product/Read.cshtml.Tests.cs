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
            Assert.AreEqual(null, pageModel.Product.Comments);
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