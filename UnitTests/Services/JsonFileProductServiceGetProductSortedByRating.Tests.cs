using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace UnitTests.Services.JsonFileProductService.GetProductSortedByRating
{
    /// <summary>
    /// Json Product services test for sorting by artist name
    /// </summary>
    public class JsonFileProductServiceGetProductSortedByRating
    {
        #region TestSetup

        /// <summary>
        /// Initializes Tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region  GetProductSortedByRating
        /// <summary>
        /// Test that method returns a sorted list when called
        /// </summary>
        [Test]
        public void GetProductSortedByDescRating_Valid_Should_Return_Sorted_Products()
        {
            // Arrange

            // Act
            var productsSorted = TestHelper.ProductService.GetProductSortedByDescRating();

            // Assert
            for (int i = 1; i < productsSorted.Count(); i++)
            {
                if (productsSorted.ElementAt(i).Ratings == null || productsSorted.ElementAt(i).Ratings == null)
                {
                    break;
                }
                double previous = productsSorted.ElementAt(i - 1).Ratings.Average();
                double current = productsSorted.ElementAt(i).Ratings.Average();

                // check that the previous item is not the same as the current
                Assert.IsTrue((((int)previous) - ((int)current)) >= 0);
            }
        }
        #endregion  GetProductSortedByRating
    }
}