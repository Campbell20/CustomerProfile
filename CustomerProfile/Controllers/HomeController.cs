using CustomerProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerProfile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(CustomerData customerdata)
        {
            ViewBag.Message = "Your application description page.";

            switch (customerdata.CustomerFirstName)
            {
                case "John":
                    ViewData["CustomerStatus"] = true;
                    break;
            }

            switch (customerdata.CustomerLastName)
            {
                case "Campbell":
                    ViewData["CustomerStatus"] = true;
                    break;
                default:
                    ViewData["CustomerStatus"] = false;
                    break;
            }
            //ViewData["Hello"] = "Response Data";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}