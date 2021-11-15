using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace UnitTests.Services.JsonFileProductService.GetProductSortedByArtist
{
    /// <summary>
    /// Json Product services test for sorting by artist name
    /// </summary>
    public class JsonFileProductServiceGetProductSortedByArtist
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

        #region GetProductSortedByArtist
        /// <summary>
        /// Test that method returns a sorted list when called
        /// </summary>
        [Test]
        public void GetProductSortedByArtist_Valid_Should_Return_Sorted_Products()
        {
            // Arrange
            var productsNotSorted = TestHelper.ProductService.GetProducts();            

            //// Act
            var productsSorted = TestHelper.ProductService.GetProductSortedByArtist();

            // Assert
            for (int i = 1; i < productsSorted.Count(); i++)
            {                
                string previous = productsSorted.ElementAt(i - 1).Artist;
                string current = productsSorted.ElementAt(i).Artist;

                // check that the previous item is less than or equal to the current
                Assert.True(String.Compare(previous, current) <= 0);
           }
        }
        #endregion GetProductSortedByArtist

        #region  GetProductSortedByRating
        /// <summary>
        /// Test that method returns a sorted list when called
        /// </summary>
        [Test]
        public void GetProductSortedByRating_Valid_Should_Return_Sorted_Products()
        {
            // Arrange

            // Act
            var productsSorted = TestHelper.ProductService.GetProductSortedByRating();

            // Assert
            for (int i = 1; i < productsSorted.Count(); i++)
            {
                if (productsSorted.ElementAt(i).Ratings == null || productsSorted.ElementAt(i).Ratings == null)
                {
                    break;
                }
                double previous = productsSorted.ElementAt(i-1).Ratings.Average();
                double current = productsSorted.ElementAt(i).Ratings.Average();

                // check that the previous item is not the same as the current
                Assert.IsTrue((((int)previous) - ((int)current)) >= 0);
            }
        }
        #endregion  GetProductSortedByRating
    }
}