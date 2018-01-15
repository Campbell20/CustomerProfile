using System;
using System.Web.Mvc;
using CustomerProfile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerProfile.Controllers;

namespace CustomerProfile.tests.Controllers
{
    [TestClass]
    public class HomeImageControllerTest
    {
        [TestMethod]
        public void ImageIndex()
        {

            var CS = "CustomerStatus";

            HomeController homeImageController = new HomeController();

            Image image = new Image
            {
                ImageName = "abc123"
            };

            ViewResult imageresult = homeImageController.ImageIndex(image) as ViewResult;

            Assert.AreEqual(true, imageresult.ViewData[CS]);
        }
    }
}
