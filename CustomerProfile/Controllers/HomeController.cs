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


        public ActionResult ImageIndex(Image image)
        {
            var CS = "CustomerStatus";
            switch (image.ImageName)
            {
                case "abc123":
                    ViewData[CS] = true;
                    break;
                default:
                    ViewData[CS] = false;
                    break;
            }
            return View();
        }

        public ActionResult About(CustomerData customerdata)
        {
            var cS = "CustomerStatus";
            ViewBag.Message = "Your application description page.";

            switch (customerdata.CustomerFirstName)
            {
                case "John":
                    ViewData[cS] = true;
                    break;
            }

            switch (customerdata.CustomerLastName)
            {
                case "Campbell":
                    ViewData[cS] = true;
                    break;
                default:
                    ViewData[cS] = false;
                    break;
            }
            //ViewData["Hello"] = "Response Data";

            if(customerdata.City == "San Antonio")
            {
                ViewData[cS] = true;
            }
            else
            {
                ViewData[cS] = false;
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}