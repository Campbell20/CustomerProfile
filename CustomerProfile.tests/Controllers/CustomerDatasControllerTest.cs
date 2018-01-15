using System;
using CustomerProfile.Controllers;
using CustomerProfile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace CustomerProfile.tests.Controllers
{
    [TestClass]
    public class CustomerDatasControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var CS = "CustomerStatus";

            CustomerDatasController controller = new CustomerDatasController();

            CustomerData customerdata = new CustomerData
            {

                // Only adjust these values when performing a unit test. Default values for each line are given.
                CustomerFirstName = "FirstName", //FirstName
                CustomerLastName = "LastName",  //LastName
                Line1 = "Line1", //Line1
                Line2 = "Line2", //Line2
                City = "CityName", //Line3
                State = "StateName", //State
                Country = "CountryName", //Country
                ZipCode = 123456, //123456
                Id = 1234 //1234
            };

            ViewResult result = controller.Index(customerdata) as ViewResult;

            Assert.AreEqual(true, result.ViewData[CS]);
        }
    }
}
