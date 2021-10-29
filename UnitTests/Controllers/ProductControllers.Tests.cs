using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Controllers;

namespace UnitTests.Controllers
{
    public class ProductControllers
    {
        #region TestSetup
        public static ProductControllers controller;

        [SetUp]
        public void TestInitialize()
        {
            controller = new ProductControllers()
            {
            };
        }

        #endregion TestSetup
    }
}
