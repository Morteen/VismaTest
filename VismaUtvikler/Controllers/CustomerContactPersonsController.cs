using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VismaUtvikler.Models;

namespace VismaUtvikler.Controllers
{
    public class CustomerContactPersonsController : Controller
    {

        private Models.ApplicationDbContext db = new ApplicationDbContext();

        

        // GET: CustomerContactPersons
        public ActionResult Index()
        {
            return View();
        }



        // GET: CustomerContactPersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           CustomerContactPerson contactPerson = db.ContactPersons.Find(id);
            if (contactPerson == null)
            {
                return HttpNotFound();
            }
            return View(contactPerson);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerContactPerson contactPerson)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(contactPerson).State = EntityState.Modified;
                var contactInDb = db.ContactPersons.Find(contactPerson.Id);
                contactInDb.FirstName = contactPerson.FirstName;
                contactInDb.lastName = contactPerson.lastName;
                contactInDb.Adress = contactPerson.Adress;
                contactInDb.PostalCode = contactPerson.PostalCode;
                contactInDb.PhoneNumber = contactPerson.PhoneNumber;
                db.SaveChanges();
                return RedirectToAction("Details","Customers",new {id=contactPerson.CustomerId});
            }
            return View(contactPerson);
        }


    }
}