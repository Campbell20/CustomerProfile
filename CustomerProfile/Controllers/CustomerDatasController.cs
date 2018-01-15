using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerProfile.Context;
using CustomerProfile.Models;
using PagedList;

namespace CustomerProfile.Controllers
{
    public class CustomerDatasController : Controller
    {
        public ActionResult Index(CustomerData customerdata)
        {
            var CS = "CustomerStatus";

            var zipcodeCheck = customerdata.ZipCode;
            var idCheck = customerdata.Id; //1234
            string[] customerDataCheck = new string[]
            {
               customerdata.CustomerFirstName,
               customerdata.CustomerLastName,
               customerdata.Line1,
               customerdata.Line2,
               customerdata.City,
               customerdata.State,
               customerdata.Country
            };

            if 
                (
               customerDataCheck[0] == "FirstName"
               && customerDataCheck[1] == "LastName"
               && customerDataCheck[2] == "Line1"
               && customerDataCheck[3] == "Line2"
               && customerDataCheck[4] == "CityName"
               && customerDataCheck[5] == "StateName"
               && customerDataCheck[6] == "CountryName"
               && zipcodeCheck == 123456
               && idCheck == 1234
                )
            {
                ViewData[CS] = true;
            }
            else
            {
                ViewData[CS] = false;
            }

            return View();
        }
        
        private CustomerDataContext db = new CustomerDataContext();
        #region Old Index
        //// GET: CustomerDatas
        //public ActionResult Index()
        //{
        //    return View(db.CustomerDatas.ToList());
        //}
        #endregion

      
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {


            //Creates a temp sortting order
            ViewBag.CurrentSort = sortOrder;

            //This checks to see if searchstring is null or not, and if searchstring IS NULL , then list page one
            if (searchString != null)
            {
                page = 1;

            }
            else
            {
                // if it's NOT NULL then assign the current filter to the searchstring paramter
                searchString = currentFilter;
            }

            // filter the values of teh database
            var Results = (IQueryable<CustomerData>)db.CustomerDatas;


            //assign searchstring to whatever the currentfilter is
            ViewBag.CurrentFilter = searchString;

            //if the user types in anything in the search box, search the database
            if (!String.IsNullOrEmpty(searchString))
            {
                Results = Results.Where(x => x.CustomerFirstName.Contains(searchString)
                || x.CustomerLastName.Contains(searchString)
                  || x.Line1.Contains(searchString)
                    || x.Line2.Contains(searchString)
                      || x.State.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "CustomerFirstName":
                    Results = Results.OrderByDescending(x => x.CustomerFirstName);
                    break;
                case "CustomerLastName":
                    Results = Results.OrderByDescending(x => x.CustomerLastName);
                    break;
                case "Line1":
                    Results = Results.OrderByDescending(x => x.Line1);
                    break;
                case "Line2":
                    Results = Results.OrderByDescending(x => x.Line2);
                    break;
                case "State":
                    Results = Results.OrderByDescending(x => x.State);
                    break;
                default:
                    Results = Results.OrderByDescending(x => x.Id);
                    break;

            }


            int pageSize = 6;
            int pageNumber = (page ?? 1);

            //return the results of the search
            return View(Results.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerDataViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.File != null)
                {
                    //string pic = string.Concat(String.Format("{0:s}", DateTime.Now), Path.GetFileName(model.File.FileName));
                    string pic = Path.GetFileName(model.File.FileName);
                    string dirPath = Server.MapPath("~/images/");
                    if (!System.IO.Directory.Exists(dirPath))
                    {
                        System.IO.Directory.CreateDirectory(dirPath);
                    }

                    string path = Path.Combine(
                                         Server.MapPath("~/images"), pic);

                    //Save the image
                    model.File.SaveAs(path);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        model.File.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }

                    model.CustomerDatas.Image = new Image();
                    model.CustomerDatas.Image.ImageName = model.File.FileName;
                }

                db.CustomerDatas.Add(model.CustomerDatas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
         

        // GET: CustomerDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerData customerData = db.CustomerDatas.Find(id);
            if (customerData == null)
            {
                return HttpNotFound();
            }
            return View(customerData);
        }

        //// GET: CustomerDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //private ActionResult Create([Bind(Include = "Id,CustomerFirstName,CustomerLastName,Line1,Line2,City,State,Country,ZipCode")] CustomerData customerData)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CustomerDatas.Add(customerData);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(customerData);
        //}

        //// GET: CustomerDatas/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CustomerData customerData = db.CustomerDatas.Find(id);
        //    if (customerData == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customerData);
        //}

        // POST: CustomerDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerFirstName,CustomerLastName,Line1,Line2,City,State,Country,ZipCode")] CustomerData customerData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerData);
        }

        // GET: CustomerDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerData customerData = db.CustomerDatas.Find(id);
            if (customerData == null)
            {
                return HttpNotFound();
            }
            return View(customerData);
        }

        // POST: CustomerDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerData customerData = db.CustomerDatas.Find(id);
            db.CustomerDatas.Remove(customerData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
