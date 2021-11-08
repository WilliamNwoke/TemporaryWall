using NUnit.Framework;
using System.Linq;

namespace UnitTests.Services.JsonFileProductService.AddComment
{
    /// <summary>
    /// Json Product services test
    /// </summary>
    public class JsonFileProductServiceAddCommentTests
    {
        #region TestSetup

        // test initialize
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        // function to test the add comment or pass
        #region AddComment
        [Test]
        public void AddComment_Valid_Data_Valid_Comment_Valid_AddComment_Should_Pass()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().First();
            // Act
            TestHelper.ProductService.AddComment(data.Id, data.Title);
            // Assert

        }
        #endregion AddComment
        // Function to test the add comment
        #region AddComment
        [Test]
        public void AddComment_Valid__Data_Valid_Comment_Invalid_AddComment_Should_Pass()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().Last();

            // Act
            TestHelper.ProductService.AddComment(data.Id, null);

            // Assert

        }
        #endregion AddComment

        // function to return product model as string
        #region ProductModeltoString
        [Test]
        public void ProductModeltoString_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var data = TestHelper.ProductService.GetProducts().First();

            // Assert
            Assert.IsNotNull(data);
        }
        #endregion ProductModeltoString
    }
}