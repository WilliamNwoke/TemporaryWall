using NUnit.Framework;
using System.Linq;

namespace UnitTests.Pages.Product.AddRating
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region AddRating
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange
            var data = TestHelper.ProductService.AddRating(null, 1);

            // Act

            // Assert
            Assert.AreEqual(false, data);
        }

        [Test]
        public void AddRating_Valid_Product_InValid_Should_Return_False()
        {
            // Arrange
            var data = TestHelper.ProductService.AddRating("fdg", 5);

            // Act

            // Assert
            Assert.AreEqual(false, data);
        }

        [Test]
        public void AddRating_Valid_Product_Valid_AddRating_SmallThanZero_Should_Return_False_()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Valid_AddRating_BiggerThanFive_Should_Return_False()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Valid_AddRating_Valid_Result_ValveIsNull_Should_Return_True()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().Last();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 4);

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }
        #endregion AddRating
    }
}

namespace UnitTests.Pages.Product.AddComment
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region AddComment
        [Test]
        public void AddComment_Valid_Should_GetAllData()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().First();
            var data2 = TestHelper.ProductService.GetAllData().Last();
            // Act

            // Assert
            TestHelper.ProductService.AddComment(data.Id, data.Title);
            TestHelper.ProductService.AddComment(data2.Id, null);
        }
        #endregion AddComment
    }
}