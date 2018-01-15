using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerProfile.Controllers;
using System.Web.Mvc;
using CustomerProfile.Models;

namespace CustomerProfile.tests
{
    [TestClass]
    public class HomeControllerTest
    {
       
        [TestMethod]
        public void About()
        {
            var cS = "CustomerStatus";

            HomeController controller = new HomeController();

            CustomerData customerdata = new CustomerData
            {
                CustomerFirstName = "John",
                CustomerLastName = "Campbell",
                City = "San Antonio",
            };

            ViewResult result = controller.About(customerdata) as ViewResult;

            Assert.AreEqual(true, result.ViewData[cS]);
        }
    }
}
