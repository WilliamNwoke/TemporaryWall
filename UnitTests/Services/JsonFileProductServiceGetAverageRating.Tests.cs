﻿using NUnit.Framework;
using System.Linq;

namespace UnitTests.Services.JsonFileProductService.GetAverageRating
{
    /// <summary>
    /// Json Product services test
    /// </summary>
    public class JsonFileProductServiceGetAverageRating
    {
        #region TestSetup

        // test initialize
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup


        #region GetAverageRating
        [Test]
        public void GetAverageRating_Valid_Rating_Valid_Should_Return_True_Pass()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals("american-gothic"));

            // Act
            var result = TestHelper.ProductService.GetAverageRating(data);

            // Assert
            Assert.AreEqual(2, result);
        }


        [Test]
        public void GetAverageRating_Null_Rating_Valid_Should_Return_True_Pass()
        {
            // Arrange
            //619737e3-5880-4c1e-95d6-c079346568aa productID has null ratings
            var data = TestHelper.ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals("619737e3-5880-4c1e-95d6-c079346568aa"));

            // Act
            var result = TestHelper.ProductService.GetAverageRating(data);

            // Assert
            Assert.AreEqual(0, result);
        }
        #endregion GetAverageRating
    }
}