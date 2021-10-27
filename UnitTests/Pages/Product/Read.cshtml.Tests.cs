
using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

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
            Assert.AreEqual("The Starry Night x Vincent van Gogh", pageModel.Product.Title);
        }
        #endregion OnGet

        /*
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
     Assert.AreEqual(null, pageModel.Comment('dfds');
 }
 #endregion GetComment


 #region OnPost
 [Test]
 public void OnPost_Valid_Should_Pass()
 {
     // Arrange

     // Act
     pageModel.OnPost();

     // Assert
     Assert.AreEqual(true, result);
 }
 #endregion OnPost*/
    }
}