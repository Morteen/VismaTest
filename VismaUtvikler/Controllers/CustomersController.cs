using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VismaUtvikler.Models;
using VismaUtvikler.ViewModels;

namespace VismaUtvikler.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }








        public ActionResult addCustomer()
        {
            //db.Customers.Add(customer);

            return View();
        }

        [HttpPost]
        public ActionResult lagKunde(Customer customer)
        {
            if (customer == null)
            {
                return HttpNotFound();
            }
            db.Customers.Add(customer);
            db.SaveChanges();

            return RedirectToAction("Index","Customers");
        }



       ///Get
        public ActionResult NyKontakt(int? id)
       {


           var ViewModel = new CustomerViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest,"KOMMER BARE HIT");
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound("hEI HEI");
            }

           ViewModel.Customer = customer;
            return View(ViewModel);

          
        }

        [HttpPost, ActionName("NyKontakt")]
       
        public ActionResult NyKontakt(int id,CustomerContactPerson contactPerson)
        {
            Customer customer = db.Customers.Find(id);
            contactPerson.CustomerId = id;
            customer.ContactPersons.Add(contactPerson);
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", "Customers", new { id = id });
        }










        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            List <CustomerContactPerson> contactPersons = db.ContactPersons.ToList();
            customer.ContactPersons = contactPersons.Where(i => i.CustomerId == customer.Id).ToList();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        // GET: Customers/Create
        public ActionResult Create()

        {
            
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirmName,Adress,PostalCode,PhoneNumber,FaxNumber,MailAdress")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }


        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirmName,Adress,PostalCode,PhoneNumber,FaxNumber,MailAdress")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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


        ////Min action
        public ActionResult New()
        {
            var CustomerTypes = db.CustomerTypes.ToList();
            var NewCustomerviewModel = new CustomerViewModel
            {
                CustomerTypes = CustomerTypes
            };
            return View(NewCustomerviewModel);
        }
    }
}
